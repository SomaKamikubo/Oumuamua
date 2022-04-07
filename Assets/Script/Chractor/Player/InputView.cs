using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class InputView : CharactorInput
{
    public event Action<bool> OnShiftKeydownedListener;

    ReactiveProperty<bool> _isDownSKey = new ReactiveProperty<bool>();
    ReactiveProperty<bool> _isDownShiftKey = new ReactiveProperty<bool>();


    public IObservable<bool> OnDownSKey { get { return _isDownSKey; } }
    public IReadOnlyReactiveProperty<bool> OnDownShiftKey { get { return _isDownShiftKey; } }



    void Start()
    {
        //keyが押されたら
        this.UpdateAsObservable()
            .Where(_ => Input.anyKeyDown)
            .Subscribe(_ => { 
                _DownKey.OnNext(InputKey()); 
            });


        //長押し検知はこっちで。時間あるときに簡略化
        //s長押し
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.S))
            .Subscribe(_ => LongDownKey("s", Input.GetKeyDown(KeyCode.S)));

        //Shift長押し
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
            .Subscribe(_ => LongDownKey("LeftShift", Input.GetKeyDown(KeyCode.LeftShift)));

        //横入力
        this.UpdateAsObservable()
            .Subscribe(_ => { _isDownHorizontal.OnNext(Input.GetAxis("Horizontal")); });
    }


    //引数に押されたキーが入るといいかも？
    void LongDownKey(string key, bool downing)
    {
        switch (key)
        {
            case "s":
                _isDownSKey.Value = Input.GetKey(KeyCode.S);
                break;
            case "LeftShift":
                _isDownShiftKey.Value = Input.GetKey(KeyCode.LeftShift);
                break;
        }
    }

    //何キーが押されたか判断
    //Enumの値を指定の値にする（いつの日か。）
    string InputKey()
    {
        foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(code))
            {
                
                return code.ToString();
            }
        }
        return "keyが見つかりません。";
    }

}
