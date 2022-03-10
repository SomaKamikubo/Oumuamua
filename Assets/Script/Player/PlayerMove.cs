using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int moveSpeed;
    [SerializeField] GameObject player;
    PlayerStatus player_status;
    // Start is called before the first frame update
    void Start()
    {
        player_status = player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            //îΩì]èàóù
            Reverse();

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("shift");
                Dash();
                Debug.Log(player_status.IsDashing);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                player_status.IsDashing = false;
            }

            else
            {
                Walk();
            }
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            return;
        }

 

        else
        {
            player_status.IsWalking = false;
        }


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
        player_status.IsWalking = true;
    }

    void Dash()
    {
        player_status.IsWalking = false;
        player_status.IsDashing = true;
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
