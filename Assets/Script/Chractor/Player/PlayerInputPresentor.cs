using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerInputPresentor : MonoBehaviour
{
    [SerializeField] InputView _inputView;
    [SerializeField] PlayerWindow _playerWindow;

    void Start()
    {
        //horizontal‚Ì•û‚àOnDownKey‚É‚Ü‚Æ‚ß‚½‚¢
        _inputView.OnDownHorizontalKey.Subscribe(value => _playerWindow.Move(value));
        _inputView.OnDownKey.Subscribe(key => ProcessKey(key));
        _inputView.OnDownSKey.Subscribe(isKeyPressS => _playerWindow.Crounch(isKeyPressS));
        _inputView.OnDownShiftKey.Subscribe(isKeyPressShift => _playerWindow.receiveShift(isKeyPressShift));
    }

    void ProcessKey(string key)
    {
        switch (key)
        {
            case "K":
                _playerWindow.Attack();
                Debug.Log("k");

                break;
            case "Space":
                _playerWindow.Jump();
                break;
        }

    }





}
