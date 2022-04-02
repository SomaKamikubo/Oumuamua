using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class InputPresentor : MonoBehaviour
{
    [SerializeField] InputView _inputView;
    [SerializeField] PlayerWindow _playerWindow;

    void Start()
    {
        //horizontal�̕���OnDownKey�ɂ܂Ƃ߂���
        _inputView.OnDownHorizontalKey.Subscribe(value => _playerWindow.Walk(value));
        _inputView.OnDownKey.Subscribe(key => ProcessKey(key));
    }

    void ProcessKey(string key)
    {
        switch (key)
        {
            case "K":
                _playerWindow.Attack();
                break;
            case "Space":
                //_playerWindow.Jump();
                break;
        }

    }


}
