using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    bool isWalking;
    bool isDashing;
    bool isAttacking;
    bool isDashAttacking;
    public bool IsWalking { get { return this.isWalking; } set { this.isWalking = value; } }
    public bool IsDashing { get { return this.isDashing; } set { this.isDashing = value; } }
    //public bool IsAttacking { get { return this.isAttacking; } set { this.isAttacking = value; } }
    //public bool IsDashAttacking { get { return this.isDashAttacking; } set { this.isDashAttacking = value; } }
}
