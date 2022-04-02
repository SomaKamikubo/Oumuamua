using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Presenter : MonoBehaviour
{
    [SerializeField] InputView _inputView;
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] Player _player;
    [SerializeField] UIView _uiView;
    //[SerializeField] PlayerStatus _status;
    int _count;

    private void Start()
    {

        _count = _player.getHP();
        //viewからmodelへ
        _inputView.OnDownHorizontalKey.Subscribe(amount => _playerMove.Move(amount));
        _inputView.OnDownKey.Subscribe(key => ProcessKey(key));
        _inputView.OnDownSKey.Subscribe(isKeyPressS => _playerMove.Crounch(isKeyPressS));
        _inputView.OnDownShiftKey.Subscribe(isKeyPressShift => _playerMove.receiveShift(isKeyPressShift));


        //MoveModelからviewへ
        _playerMove.OnChangeIsJumping.Subscribe(value => _inputView.SetAnimator("IsJumping", value));
        _playerMove.OnChangeIsFalling.Subscribe(value => { _inputView.SetAnimator("IsFalling", value); ; });
        _playerMove.OnChangeIsWalking.Subscribe(value => { _inputView.SetAnimator("IsWalking", value); });
        _playerMove.OnChangeIsDashing.Subscribe(value => _inputView.SetAnimator("IsDashing", value));
        _playerMove.OnChangeIsCrouching.Subscribe(value => _inputView.SetAnimator("IsCrouching", value));


        //AtackModelからviewへ
        _playerAttack.OnAttack.Subscribe(value => _inputView.SetAnimatorTrigger(value));

        //Playerからviewへ
        _player.OnHurt.Subscribe(value => { 
            _inputView.SetAnimatorTrigger(value);
            _uiView.ViewHurt(_player.getHP());
         });
        _player.OnDeath.Subscribe(value => _inputView.SetAnimatorTrigger(value));


        void ProcessKey(string key)
        {
            switch (key)
            {
                case "K":
                    _playerAttack.Attack();
                    break;
                case "Space":
                    _playerMove.Jump();
                    break;
            }

        }   
    }

}
