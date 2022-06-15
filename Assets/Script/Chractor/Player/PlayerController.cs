using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController :CharactorController
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] protected AnimatorView _playerAnimatorView;
    protected override void Start() {
        _animatorView = _playerAnimatorView;
        _charactorWindow = _playerWindow;
        base.Start();
        _playerWindow.OnChangeIsJumping.Subscribe(value => { _canAttack = !value; Debug.Log("junmp:"+value); Debug.Log("Attack:" + _canAttack); });
    }
}
