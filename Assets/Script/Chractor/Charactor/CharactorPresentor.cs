using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CharactorPresentor : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;
    protected CharactorInput _charactorInput;

    protected virtual void Start()
    {
        //view‚©‚çwindow
        _charactorInput.OnDownHorizontalKey.Subscribe(value => _charactorWindow.Walk(value));
        _charactorInput.OnDownKey.Subscribe(key => ProcessKey(key));

        //window‚©‚çview
        _charactorWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _charactorWindow.OnAttack.Subscribe(value => { _animatorView.SetAnimatorTrigger(value); _animatorView.StartCoroutine("PlayAnimation", "Attack"); });
        _charactorWindow.OnDeath.Subscribe(value => _animatorView.SetAnimatorTrigger(value));
        _charactorWindow.OnHurt.Subscribe(value => _animatorView.SetAnimatorTrigger(value));


        
    }

    protected virtual void ProcessKey(string key)
    {
        switch (key)
        {
            case "K":
                _charactorWindow.Attack();
                break;
        }

    }
}
