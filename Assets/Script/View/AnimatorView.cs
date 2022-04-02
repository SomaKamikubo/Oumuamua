using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class AnimatorView : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void SetAnimator(string bool_name, bool isActing)
    {
        animator.SetBool(bool_name, isActing);
    }

    public void SetAnimatorTrigger(string TriggerName)
    {
        animator.SetTrigger(TriggerName);
    }

}
