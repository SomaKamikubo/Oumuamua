using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerAnimatorPresentor : CharactorAnimatorPresentor
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] AnimatorView _playerAnimatorView;

    void Start()
    {
        _charactorWindow = _playerWindow;
        _animatorView = _playerAnimatorView;
        CharactorAnimeEvent();
        _playerWindow.OnChangeIsJumping.Subscribe(value => _animatorView.SetAnimator("IsJumping", value));
        _playerWindow.OnChangeIsFalling.Subscribe(value => { _animatorView.SetAnimator("IsFalling", value); });
        _playerWindow.OnChangeIsDashing.Subscribe(value => _animatorView.SetAnimator("IsDashing", value));
        _playerWindow.OnChangeIsCrouching.Subscribe(value => _animatorView.SetAnimator("IsCrouching", value));
    }

}
