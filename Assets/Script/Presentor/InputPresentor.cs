using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class InputPresentor : MonoBehaviour
{
    //[SerializeField] CharactorWindow _charactorWindow;
    [SerializeField] InputView _inputView;
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] EnemyWindow _enemyWindow;

    void Start()
    {
        //horizontal‚Ì•û‚àOnDownKey‚É‚Ü‚Æ‚ß‚½‚¢
        _inputView.OnDownHorizontalKey.Subscribe(value => _playerWindow.Move(value));
        _inputView.OnDownKey.Subscribe(key => ProcessKey(key));
        _inputView.OnDownSKey.Subscribe(isKeyPressS => _playerWindow.Crounch(isKeyPressS));
        _inputView.OnDownShiftKey.Subscribe(isKeyPressShift => _playerWindow.receiveShift(isKeyPressShift));

        _inputView.OnDownHorizontalKey.Subscribe(value => _enemyWindow.Walk(value));
        _inputView.OnDownKey.Subscribe(key => ProcessKey(key));
        
    }

    void ProcessKey(string key)
    {
        switch (key)
        {
            case "K":
                _playerWindow.Attack();
                _enemyWindow.Attack();
                break;
            case "Space":
                _playerWindow.Jump();
                break;
        }

    }


}
