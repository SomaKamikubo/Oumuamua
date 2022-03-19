using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

[RequireComponent(typeof(Animator))]

public class Presenter : MonoBehaviour
{
    [SerializeField] InputView _inputView;
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] Player _player;
    //[SerializeField] PlayerStatus _status;

    private void Start()
    {

        //viewからmodelへ
        _inputView.OnDownHorizontalKey.Subscribe(amount => _playerMove.Move(amount));
        _inputView.OnDownKey.Subscribe(key => ProcessKey(key));
        _inputView.OnDownSKey.Subscribe(isKeyPressS => _playerMove.Crounch(isKeyPressS));
        _inputView.OnDownShiftKey.Subscribe(isKeyPressShift => _playerMove.receiveShift(isKeyPressShift));


        //MoveModelからviewへ
        //コールバック関数にする
        _playerMove.OnChangeIsJumping.Subscribe(value => _inputView.SetAnimator("IsJumping", value));
        _playerMove.OnChangeIsFalling.Subscribe(value => {_inputView.SetAnimator("IsFalling", value);; });
        _playerMove.OnChangeIsWalking.Subscribe(value => { _inputView.SetAnimator("IsWalking", value);});
        _playerMove.OnChangeIsDashing.Subscribe(value => _inputView.SetAnimator("IsDashing", value));
        _playerMove.OnChangeIsCrouching.Subscribe(value => _inputView.SetAnimator("IsCrouching", value));


        //AtackModelからviewへ
        _playerAttack.OnAttack.Subscribe(value => _inputView.SetAnimatorTrigger(value));

        //Playerからviewへ
        _player.OnHurt.Subscribe(value => _inputView.SetAnimatorTrigger(value));
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
