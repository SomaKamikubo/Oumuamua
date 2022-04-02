using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class AnimatorPresentor : MonoBehaviour
{
    //[SerializeField] CharactorWindow _charactorWindow;
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] AnimatorView _animatorView;
    void Start()
    {
        _playerWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _playerWindow.OnAttack.Subscribe(value =>{ _animatorView.SetAnimatorTrigger(value); Debug.Log("kougeki"); });

        _playerWindow.OnChangeIsJumping.Subscribe(value => _animatorView.SetAnimator("IsJumping", value));
        _playerWindow.OnChangeIsFalling.Subscribe(value => { _animatorView.SetAnimator("IsFalling", value); });
        _playerWindow.OnChangeIsDashing.Subscribe(value => _animatorView.SetAnimator("IsDashing", value));
        _playerWindow.OnChangeIsCrouching.Subscribe(value => _animatorView.SetAnimator("IsCrouching", value));
    }



    
}
