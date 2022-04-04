using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class CharactorAnimatorPresentor : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;

    protected virtual void Start()
    {
        _charactorWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); } );
        _charactorWindow.OnAttack.Subscribe(value => { _animatorView.SetAnimatorTrigger(value); _animatorView.StartCoroutine("PlayAnimation", "Attack"); });
        _charactorWindow.OnDeath.Subscribe(value => _animatorView.SetAnimatorTrigger(value));
        _charactorWindow.OnHurt.Subscribe(value => _animatorView.SetAnimatorTrigger(value));
    }

    
}
