using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;



public class InputPresentor : MonoBehaviour
{
    //[SerializeField] CharactorWindow _charactorWindow;
    [SerializeField] InputView _inputView;
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] EnemyController _enemyController;
    [SerializeField] EnemyWindow _enemyWindow;

    void Start()
    {
        //horizontal‚Ì•û‚àOnDownKey‚É‚Ü‚Æ‚ß‚½‚¢
        _inputView.OnDownHorizontalKey.Subscribe(value => _playerWindow.Move(value));
        _inputView.OnDownKey.Subscribe(key => ProcessKey(key));
        _inputView.OnDownSKey.Subscribe(isKeyPressS => _playerWindow.Crounch(isKeyPressS));
        _inputView.OnDownShiftKey.Subscribe(isKeyPressShift => _playerWindow.receiveShift(isKeyPressShift));

        _enemyController.OnDownHorizontalKey.Subscribe(value => _enemyWindow.Walk(value));
        _enemyController.OnDownKey.Subscribe(key => _enemyWindow.Attack());
    
        
    }

    void ProcessKey(string key)
    {
        switch (key)
        {
            case "K":
                _playerWindow.Attack();
                //_enemyWindow.Attack();
                break;
            case "Space":
                _playerWindow.Jump();
                break;
        }

    }


}
