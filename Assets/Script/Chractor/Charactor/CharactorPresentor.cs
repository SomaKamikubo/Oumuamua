using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Collections;
using System.Collections.Generic;

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
    protected CharactorController _charactorController;


    protected virtual void Start()
    {
        //view����window
        _charactorInput.OnDownHorizontalKey.Subscribe(value => { if (_charactorWindow.getHp() > 0) _charactorController.ControlWalk(value); });
        _charactorInput.OnDownKey.Subscribe(key => { if (_charactorWindow.getHp() > 0) ProcessKey(key); });

        //window����view
        _charactorWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _charactorWindow.OnAttack.Subscribe(_ => { _animatorView.SetAnimatorTrigger("AttackTrigger"); });
        _charactorWindow.OnDeath.Subscribe(_ => { _animatorView.SetAnimatorTrigger("DeathTrigger"); });
        _charactorWindow.OnHurt.Subscribe(_ => _animatorView.SetAnimatorTrigger("HurtTrigger"));

       

        
    }

    Dictionary<string, string> keys = new Dictionary<string, string>() 
    {
        {"Z", "Attack"},
    };



    //�����ꂽ�L�[���Ƃɏ���������
    protected virtual void ProcessKey(string key)
    {
        try
        {
            _charactorController.Control(keys[key]);
        }
        catch(KeyNotFoundException)
        {
            Debug.Log("�L�['"+key+"'�͓o�^����Ă��܂���B");
        }
    }
}
