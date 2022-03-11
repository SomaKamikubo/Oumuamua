using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject player;
    PlayerStatus player_status;
    [SerializeField] int WalkSpeed;
    [SerializeField] int DashSpeed;
    int Speed;
    int a;

    void Start()
    {
        player_status = player.GetComponent<PlayerStatus>();
        Speed = 0;
        a = 0;
    }

    void Update()
    {
        if (player_status.IsAttacking)
        {
            Debug.Log(a);
            a += 1;
            return;
        }


        float horizontal = Input.GetAxis("Horizontal");
        player_status.IsCrouching = Input.GetKey(KeyCode.S);

        if (horizontal == 0)
        {
            player_status.IsWalking = false;
            player_status.IsDashing = false;
            return;
        }

        
        player_status.IsDashing = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.S))
        {
            Crouch();
            return;
        }

        //îΩì]èàóù
        Reverse();
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            Dash();
            Debug.Log(player_status.IsDashing);
            return;
        }

        

        player_status.IsDashing = false;
        Walk();

        
        
        


        //-------------------------
        //óùëz
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    Dash();
        //}
        //if (space)
        //{
        //    Junp();
        //}
        //if(Move)
        //{
        //    walk();
        //}


    }

    void Walk()
    {
        Speed = WalkSpeed;
        player_status.IsWalking = true;
    }

    void Dash()
    {
        Speed = DashSpeed;
        player_status.IsDashing = true;
    }

    void Crouch()
    {
        player_status.IsCrouching = Input.GetKey(KeyCode.S);
    }
    void Reverse()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 scale = gameObject.transform.localScale;
        if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
        {
            scale.x *= -1;
        }
        gameObject.transform.localScale = scale;
    }

}
