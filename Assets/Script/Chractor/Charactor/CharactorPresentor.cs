using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/*
 * Presentor
 * ViewとModelの受け渡しを行うクラス
 * ・入力をModelに渡す（入力を受け付けるかの処理も含む）
 * ・Modelの変化をViewに伝える
 */
public abstract class CharactorPresentor : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;
    protected CharactorInput _charactorInput;

    protected bool _canAttack = true;

    protected virtual void Start()
    {
        //viewからwindow
        _charactorInput.OnDownHorizontalKey.Subscribe(value => _charactorWindow.Walk(value));
        _charactorInput.OnDownKey.Subscribe(key => ProcessKey(key));

        //windowからview
        _charactorWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _charactorWindow.OnAttack.Subscribe(value => {_animatorView.SetAnimatorTrigger(value); _animatorView.StartCoroutine("PlayAnimation", "attack2"); });
        _charactorWindow.OnDeath.Subscribe(value => _animatorView.SetAnimatorTrigger(value));
        _charactorWindow.OnHurt.Subscribe(value => _animatorView.SetAnimatorTrigger(value));

        //viewからここ
        _animatorView.OnFinish.Subscribe(_ => _canAttack = true);

        
    }

    //押されたキーごとに処理を書く
    protected virtual void ProcessKey(string key)
    {
        switch (key)
        {
            case "K":
                if (_canAttack)
                {
                    _charactorWindow.Attack();
                    _canAttack = false;
                }
                break;
        }

    }
}
