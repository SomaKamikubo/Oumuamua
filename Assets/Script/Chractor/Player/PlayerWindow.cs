using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class PlayerWindow :CharactorWindow
{
    [SerializeField] PlayerStatus _playerStatus;
    [SerializeField] PlayerHP _playerHP;
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] PlayerAttack _playerAttack;
    [SerializeField] PlayerHurt _playerHurt;

    ReactiveProperty<bool> _isJumping = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isFalling = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isCrouching = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isDashing = new ReactiveProperty<bool>(false);

    //Subject<string> _isAttacking = new Subject<string>();
    //public IObservable<string> OnAttack { get { return _isAttacking; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsJumping { get { return _isJumping; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsFalling { get { return _isFalling; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsDashing { get { return _isDashing; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsCrouching { get { return _isCrouching; } }


    //playerStatus‚Ì•ûX
    public int getDashSpeed() { return _playerStatus.getDashSpeed(); }
    public int getJumpPower() { return _playerStatus.getJumpPower(); }

    //playerMove‚Ì•ûX
    public void Move(float amount) { _playerMove.Move(amount); }
    public void Jump() { _playerMove.Jump(); }
    public void Crounch(bool value) { _playerMove.Crounch(value); }
    public void receiveShift(bool isPressShift) { _playerMove.receiveShift(isPressShift); }

    //hurt
    public void ViewHurt(int hp) { _playerHurt.ViewHurt(hp); }


    protected void Awake()
    {
        //‰Šú‰»
        _charactorAttack = _playerAttack;
        _charactorMove = _playerMove;
        _charactorStatus = _playerStatus;
        _charactorHP = _playerHP;
    }
    protected override void Start()
    {
        base.Start();
        _playerMove.OnChangeIsJumping.Subscribe(value => _isJumping.Value = value);
        _playerMove.OnChangeIsFalling.Subscribe(value =>  _isFalling.Value = value);
        _playerMove.OnChangeIsDashing.Subscribe(value => _isDashing.Value = value);
        _playerMove.OnChangeIsCrouching.Subscribe(value => _isCrouching.Value = value);

    }
}
