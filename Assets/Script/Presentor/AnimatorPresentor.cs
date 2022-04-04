using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class AnimatorPresentor : MonoBehaviour
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] EnemyWindow _enemyWindow;
    [SerializeField] AnimatorView _animatorView;

    void Start()
    {
        _playerWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _playerWindow.OnAttack.Subscribe(value => { _animatorView.SetAnimatorTrigger(value); });

        _enemyWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); Debug.Log("aruku"); });
        _enemyWindow.OnAttack.Subscribe(value => { _animatorView.SetAnimatorTrigger(value); });

        _playerWindow.OnChangeIsJumping.Subscribe(value => _animatorView.SetAnimator("IsJumping", value));
        _playerWindow.OnChangeIsFalling.Subscribe(value => { _animatorView.SetAnimator("IsFalling", value); });
        _playerWindow.OnChangeIsDashing.Subscribe(value => _animatorView.SetAnimator("IsDashing", value));
        _playerWindow.OnChangeIsCrouching.Subscribe(value => _animatorView.SetAnimator("IsCrouching", value));

        _playerWindow.OnHurt.Subscribe(value =>{ _animatorView.SetAnimatorTrigger(value); Debug.Log("UŒ‚‚ðŽó‚¯‚½"); });
        _playerWindow.OnDeath.Subscribe(value => _animatorView.SetAnimatorTrigger(value));
    }



    
}
