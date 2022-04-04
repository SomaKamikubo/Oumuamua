using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class WallSlide : MonoBehaviour
{
    [SerializeField] bool isWallSliding;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            isWallSliding = true;
            Debug.Log("aaa");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            isWallSliding = false;
        }
    }

    public bool IsWallSliding { get { return isWallSliding; } }
}
