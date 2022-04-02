using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class AnimatorPresentor : MonoBehaviour
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] AnimatorView _animatorView;
    void Start()
    {
        _playerWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value);});
        _playerWindow.OnAttack.Subscribe(value => _animatorView.SetAnimatorTrigger(value));
    }

    
}
