using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class CharactorPresentor : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;
    protected CharactorInput _charactorInput;

    protected bool _canAttack = true;

    protected virtual void Start()
    {
        //view‚©‚çwindow
        _charactorInput.OnDownHorizontalKey.Subscribe(value => _charactorWindow.Walk(value));
        _charactorInput.OnDownKey.Subscribe(key => ProcessKey(key));

        //window‚©‚çview
        _charactorWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _charactorWindow.OnAttack.Subscribe(value => { _canAttack = true; _animatorView.SetAnimatorTrigger(value); _animatorView.StartCoroutine("PlayAnimation", "attack2"); });
        _charactorWindow.OnDeath.Subscribe(value => _animatorView.SetAnimatorTrigger(value));
        _charactorWindow.OnHurt.Subscribe(value => _animatorView.SetAnimatorTrigger(value));

        //view‚©‚ç‚±‚±
        _animatorView.OnFinish.Subscribe(_ => _canAttack = true);


        
    }

    protected virtual void ProcessKey(string key)
    {
        switch (key)
        {
            case "K":
                if (_canAttack)
                {
                    _charactorWindow.Attack();
                }
                break;
        }

    }
}
