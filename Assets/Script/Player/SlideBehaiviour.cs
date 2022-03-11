using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBehaiviour : StateMachineBehaviour
{
    public float Speed = 5f;
    private CharacterController characterController;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterController = animator.GetComponent<CharacterController>();
        characterController.Move(animator.gameObject.transform.forward * Speed * Time.deltaTime);
    }
}
