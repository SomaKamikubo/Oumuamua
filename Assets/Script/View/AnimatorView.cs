using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorView : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void SetAnimator(string bool_name, bool istriggerNameing)
    {
        animator.SetBool(bool_name, istriggerNameing);
    }

    public void SetAnimatorTrigger(string TriggerName)
    {
        animator.SetTrigger(TriggerName);
    }


    private IEnumerator PlayAnimation(string animationName)
    {
        // Animator�̃X�e�[�g�ύX�ɂP�t���[��������̂ő҂�
        yield return new WaitForEndOfFrame();
        // �I������܂ő҂�
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationName));
        Debug.Log(animationName + "�A�j���[�V���� �I�������B");
    }

}
