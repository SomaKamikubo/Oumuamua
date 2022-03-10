using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMove : MonoBehaviour,IPlayerData
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int moveSpeed;
    bool isMoving = false;
    bool isWalking = false;
    bool isDashing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isMoving = horizontal != 0;

        if (isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;
            if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Dash();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isDashing = false;
            }

            else
            {
                walk();
            }
            
        }
        
        else
        {
            isWalking = false;
        }

        //-------------------------
        //—‘z
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

    void walk()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        isWalking = true;
    }

    void Dash()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        isDashing = true;
        isWalking = false;
    }

    

    public bool IsWalking { get { return isWalking; } }
    public bool IsDashing { get { return isDashing; } }
}
