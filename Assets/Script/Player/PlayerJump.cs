using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]

public class PlayerJump : MonoBehaviour
{

    [SerializeField] bool isFalling;
    [SerializeField] bool isJumping;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isFalling = rb.velocity.y < -0.5f;
        //if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        //{
        //    Jump();
        //}
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
        isJumping = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaa");
        if (collision.CompareTag("Stage"))
        {
            //isJumping = false;
            //isFalling = false;
            
        }
    }

    //public bool IsJumping { get { return isJumping; } }
    //public bool IsFalling { get { return isFalling; } }
}
