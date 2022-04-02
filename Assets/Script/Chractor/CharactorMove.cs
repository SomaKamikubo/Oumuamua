using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CharactorMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] CharactorStatus _charactorStatus;


    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    int _speed = 0;


    public void Walk(float amount)
    {
        if (amount == 0)
        {
            //Debug.Log("“®‚¢‚Ä‚¢‚È‚¢");
            SetIsWalking(false);
            return;
        }

        _speed = _charactorStatus.getWalkSpeed();
        SetIsWalking(true);
        _rb.velocity = new Vector2(amount* _speed, _rb.velocity.y);
    }


    void SetIsWalking(bool value)
    {
        _isWalking.Value = value;
    }
}
