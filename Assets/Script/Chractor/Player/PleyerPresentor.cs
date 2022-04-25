using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class PleyerPresentor : CharactorPresentor
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] AnimatorView _playerAnimatorView;
    [SerializeField] InputView _inputView;

    protected void Awake()
    {
        _charactorWindow = _playerWindow;
        _animatorView = _playerAnimatorView;
        _charactorInput = _inputView;
    }
    protected override void Start()
    {
        base.Start();
        _inputView.OnDownSKey.Subscribe(isKeyPressS =>  _playerWindow.Crounch(isKeyPressS));
        _inputView.OnDownShiftKey.Subscribe(isKeyPressShift => _playerWindow.receiveShift(isKeyPressShift));

        //model‚©‚çview‚Ö
        _playerWindow.OnChangeIsJumping.Subscribe(value => { _playerAnimatorView.SetAnimator("IsJumping", value); });
        _playerWindow.OnChangeIsFalling.Subscribe(value => { _animatorView.SetAnimator("IsFalling", value); });
        _playerWindow.OnChangeIsDashing.Subscribe(value => _animatorView.SetAnimator("IsDashing", value));
        _playerWindow.OnChangeIsCrouching.Subscribe(value => _animatorView.SetAnimator("IsCrouching", value));
        _playerWindow.OnHurt.Subscribe(_ => _playerWindow.ViewHurt(_playerWindow.getHp()));

        _playerWindow.OnAttack.Subscribe(_ => _animatorView.StartCoroutine("PlayAnimation", "Attack"));

        //view‚©‚ç‚±‚±
        _playerAnimatorView.OnFinish.Subscribe(_ => _canAttack = true);
    }

    

    protected override void ProcessKey(string key)
    {
        base.ProcessKey(key);
        switch (key)
        {
            case "Space":
                _playerWindow.Jump();
                break;
        }

    }
}
