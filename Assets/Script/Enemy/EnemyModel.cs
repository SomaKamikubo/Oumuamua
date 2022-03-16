using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class EnemyModel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int walkSpeed;
    [SerializeField] private int attackPower;
    public void Move(float horizontal) 
    {
        rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);

        Vector3 scale = gameObject.transform.localScale;
        if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
        {
            scale.x *= -1;
        }
        gameObject.transform.localScale = scale;
    }
    public void Attack() { }
    public void Death() { }
}
