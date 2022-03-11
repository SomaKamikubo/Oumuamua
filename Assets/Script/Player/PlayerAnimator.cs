using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;
    PlayerStatus player_status;
    delegate void EndEventHandler(GameObject sender);
    event EndEventHandler endEventHandler;
    void Start()
    {
        player_status = player.GetComponent<PlayerStatus>();
    }
    
    void Update()
    {
        //IPlayerData player_data = player.GetComponent<IPlayerData>();
        animator.SetBool("IsMoving", player_status.IsMoving);
        animator.SetBool("IsWalking",player_status.IsWalking);
        animator.SetBool("IsDashing", player_status.IsDashing);
        animator.SetBool("IsCrouching", player_status.IsCrouching);
        //animator.SetBool("IsAttacking", player_status.IsAttacking);
        //animator.SetBool("IsDashAttacking", player_status.IsDashAttacking);
        if (player_status.IsAttacking)
        {
            GetComponent<Animator>().SetTrigger("Attack Trigger");
            //ñ≥ñºä÷êîÇ≈èëÇ≠
            endEventHandler = Aa;
        }

    }
    void Aa(GameObject sender)
    {
        player_status.IsAttacking = false; 
        endEventHandler = null;
    }
}
