using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class CharactorController : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;

    protected ReactiveProperty<bool> _canAttack = new ReactiveProperty<bool>(true);
    //public IReadOnlyReactiveProperty<bool> OnChangeCanAttack { get { return _canAttack; } }


    protected virtual void Start()
    {
        //アニメーションが終わったことをうけとり、フラグをtureにする
        _animatorView.OnFinish.Subscribe(finishAnimation => { 
            _canAttack.Value = true;
        });
    }
    public virtual void Control(string key)
    {
        switch (key)
        {
            case "Attack"://攻撃
                if (_canAttack.Value)
                {
                    
                    //動けるなら動き、フラグをfalseにする
                    _charactorWindow.Attack();
                    _canAttack.Value = false;
                    _animatorView.StartCoroutine("PlayAnimation", "Attack");
                }
                break;
        }
    }

    public virtual void ControlWalk(float value)
    {
        if (_canAttack.Value)
        {
            _charactorWindow.Walk(value);
        }
        else
        {
            _charactorWindow.Stop();
        }
        
    }
}
