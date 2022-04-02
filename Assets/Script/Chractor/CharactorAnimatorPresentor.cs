using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class CharactorAnimatorPresentor : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;

    protected void CharactorAnimeEvent()
    {
        _charactorWindow.OnChangeIsWalking.Subscribe(value => { _animatorView.SetAnimator("IsWalking", value); });
        _charactorWindow.OnAttack.Subscribe(value => { _animatorView.SetAnimatorTrigger(value); });
    }
}
