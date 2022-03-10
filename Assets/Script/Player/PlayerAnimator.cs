using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        IPlayerData player_data = player.GetComponent<IPlayerData>();
        animator.SetBool("IsWalking", player_data.IsWalking);
        animator.SetBool("IsDashing", player_data.IsDashing);

    }
}
