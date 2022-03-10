using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

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
        //IPlayerData player_data = player.GetComponent<IPlayerData>();
        
        animator.SetBool("IsWalking",player_status.IsWalking);
        animator.SetBool("IsDashing", player_status.IsDashing);
        //animator.SetBool("IsAttacking", player_status.IsAttacking);
        //animator.SetBool("IsDashAttacking", player_status.IsDashAttacking);

    }
}
