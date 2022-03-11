using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public bool IsMoving { get; set; }
    public bool IsWalking { get; set; }
    public bool IsDashing { get; set; }
    public bool IsAttacking { get; set; }
    public bool IsDashAttacking { get; set; }
    public bool IsCrouching { get; set; }
}
