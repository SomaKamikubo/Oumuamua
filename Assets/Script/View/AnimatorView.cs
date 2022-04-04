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
        // Animatorのステート変更に１フレームかかるので待つ
        yield return new WaitForEndOfFrame();
        // 終了するまで待つ
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationName));
        Debug.Log(animationName + "アニメーション 終わったよ。");
    }

}
