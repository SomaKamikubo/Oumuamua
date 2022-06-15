using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class CharactorController : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;
    protected bool _canAttack = true;

    protected virtual void Start()
    {
        //アニメーションが終わったことをうけとり、フラグをtureにする
        _animatorView.OnFinish.Subscribe(finishAnimation => { 
            _canAttack = true;
        });
    }
    public virtual void Control(string key)
    {
        switch (key)
        {
            case "Attack"://攻撃
                if (_canAttack)
                {
                    //動けるなら動き、フラグをfalseにする
                    _charactorWindow.Attack();
                    _canAttack = false;
                    _animatorView.StartCoroutine("PlayAnimation", "Attack");
                }
                break;
        }
    }

    public virtual void ControlWalk(float value)
    {
        if (_canAttack)
        {
            _charactorWindow.Walk(value);
        }
        
    }
}
