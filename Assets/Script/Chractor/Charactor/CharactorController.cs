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
        _animatorView.OnFinish.Subscribe(finishAnimation => { 
            switch (finishAnimation)
            {
                case "Attack":
                    _canAttack = true;
                    break;
            }
        });
    }
    public virtual void Control(string key)
    {
        switch (key)
        {
            case "Attack":
                if (_canAttack)
                {
                    _charactorWindow.Attack();
                    _canAttack = false;
                    _animatorView.StartCoroutine("PlayAnimation", "Attack");
                }
                break;
        }
    }
}
