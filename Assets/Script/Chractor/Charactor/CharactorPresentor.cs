using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/*
 * Presentor
 * View��Model�̎󂯓n�����s���N���X
 * �E���͂�Model�ɓn���i���͂��󂯕t���邩�̏������܂ށj
 * �EModel�̕ω���View�ɓ`����
 */
public abstract class CharactorPresentor : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;
    protected CharactorInput _charactorInput;

    protected bool _canAttack = true;

    protected virtual void Start()
    {
        //view����window
        _charactorInput.OnDownHorizontalKey.Subscribe(value => {if(_charactorWindow.getHp() > 0) _charactorWindow.Walk(value); });
        _charactorInput.OnDownKey.Subscribe(key => { if (_charactorWindow.getHp() > 0) ProcessKey(key); });

        //window����view
        _charactorWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _charactorWindow.OnAttack.Subscribe(value => {_animatorView.SetAnimatorTrigger(value);  });
        _charactorWindow.OnDeath.Subscribe(value => _animatorView.SetAnimatorTrigger(value));
        _charactorWindow.OnHurt.Subscribe(value => _animatorView.SetAnimatorTrigger(value));

       

        
    }

    //�����ꂽ�L�[���Ƃɏ���������
    protected virtual void ProcessKey(string key)
    {
        switch (key)
        {
            case "Z":
                if (_canAttack)
                {
                    _charactorWindow.Attack();
                    //_canAttack = false;
                }
                break;
        }

    }
}
