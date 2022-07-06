using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Collections;
using System.Collections.Generic;

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
    protected CharactorController _charactorController;


    protected virtual void Start()
    {
        //viewからwindow
        _charactorInput.OnDownHorizontalKey.Subscribe(value => { if (_charactorWindow.getHp() > 0) _charactorController.ControlWalk(value); });
        _charactorInput.OnDownKey.Subscribe(key => { if (_charactorWindow.getHp() > 0) ProcessKey(key); });

        //windowからview
        _charactorWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _charactorWindow.OnAttack.Subscribe(_ => { _animatorView.SetAnimatorTrigger("AttackTrigger"); });
        _charactorWindow.OnDeath.Subscribe(_ => { _animatorView.SetAnimatorTrigger("DeathTrigger"); });
        _charactorWindow.OnHurt.Subscribe(_ => _animatorView.SetAnimatorTrigger("HurtTrigger"));

       

        
    }

    Dictionary<string, string> keys = new Dictionary<string, string>() 
    {
        {"Z", "Attack"},
    };



    //押されたキーごとに処理を書く
    protected virtual void ProcessKey(string key)
    {
        try
        {
            _charactorController.Control(keys[key]);
        }
        catch(KeyNotFoundException)
        {
            Debug.Log("キー'"+key+"'は登録されていません。");
        }
    }
}
