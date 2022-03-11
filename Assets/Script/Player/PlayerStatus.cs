using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの状態を管理するクラス
public class PlayerStatus : MonoBehaviour
{

    [SerializeField] PlayerAttack player_attack;
    [SerializeField] PlayerMove player_move;

    public bool IsAttacking { get { return player_attack.IsAttacking; } }
    public bool IsMoving { get { return player_move.IsMoving; } }
    public bool IsWalking { get { return player_move.IsWalking; } }
    public bool IsDashing { get { return player_move.IsDashing; } }
    public bool IsCrouching { get { return player_move.IsCrouching; } }
    public bool IsJumping { get { return player_move.IsJumping; } }
    public bool IsFalling { get { return player_move.IsFalling; } }
}
