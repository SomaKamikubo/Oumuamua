using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class AnimatorView : MonoBehaviour
{
    [SerializeField] Animator animator;

    

    protected Subject<Unit> _isFinished = new Subject<Unit>();
    public IObservable<Unit> OnFinish { get { return _isFinished; } }

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
        _isFinished.OnNext(Unit.Default);
    }

}
