using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

//プレイヤーのアニメーションを設定するクラス
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    PlayerStatus player_status;
    void Start()
    {
        player_status = player.GetComponent<PlayerStatus>();
    }
    
    void Update()
    {
        //毎改書くの面倒、インターフェースでなんとかならんか？
        //IPlayerData player_data = player.GetComponent<IPlayerData>();
        animator.SetBool("IsMoving", player_status.IsMoving);
        animator.SetBool("IsWalking",player_status.IsWalking);
        animator.SetBool("IsDashing", player_status.IsDashing);
        //animator.SetBool("IsCrouching", player_status.IsCrouching);
        animator.SetBool("IsJumping", player_status.IsJumping);
        animator.SetBool("IsFalling", player_status.IsFalling);
        animator.SetBool("IsWallSliding", player_status.IsWallSliding);
        if (player_status.IsAttacking)
        {
            GetComponent<Animator>().SetTrigger("Attack Trigger");
        }
    }
}
