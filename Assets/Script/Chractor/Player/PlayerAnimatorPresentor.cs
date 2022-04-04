using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerAnimatorPresentor : CharactorAnimatorPresentor
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] AnimatorView _playerAnimatorView;
    [SerializeField] Animator animator;

    protected void Awake()
    {
        _charactorWindow = _playerWindow;
        _animatorView = _playerAnimatorView;
    }
    protected override void Start()
    {
        base.Start();
        _playerWindow.OnChangeIsJumping.Subscribe(value => { _playerAnimatorView.StartCoroutine(PlayAnimation("IsJumping",value)); });
        _playerWindow.OnChangeIsFalling.Subscribe(value => { _animatorView.SetAnimator("IsFalling", value); });
        _playerWindow.OnChangeIsDashing.Subscribe(value => _animatorView.SetAnimator("IsDashing", value));
        _playerWindow.OnChangeIsCrouching.Subscribe(value => _animatorView.SetAnimator("IsCrouching", value));

        _playerWindow.OnHurt.Subscribe(_ => _playerWindow.ViewHurt(_playerWindow.getHp()));
    }

    private IEnumerator PlayAnimation(string act,bool value)
    {
        _animatorView.SetAnimator("IsJumping", value);
        // Animatorのステート変更に１フレームかかるので待つ
        yield return new WaitForEndOfFrame();
        // 終了するまで待つ
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName(act));
        Debug.Log(act + "アニメーション 終わったよ。");
    }

}
