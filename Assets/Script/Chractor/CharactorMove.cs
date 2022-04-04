using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
//[RequireComponent(typeof(Rigidbody2D))]

public abstract class CharactorMove : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    protected CharactorStatus _charactorStatus;


    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    int _speed = 0;
    Vector3 _scale;


    public virtual void Walk(float amount)
    {
        _scale = gameObject.transform.localScale;
        if (amount < 0 && _scale.x > 0 || amount > 0 && _scale.x < 0)
        {
            _scale.x *= -1;
        }
        gameObject.transform.localScale = _scale;

        if (amount == 0)
        {
            SetIsWalking(false);
            return;
        }

        _speed = _charactorStatus.getWalkSpeed();
        SetIsWalking(true);
        _rb.velocity = new Vector2(amount* _speed, _rb.velocity.y);
    }


    protected void SetIsWalking(bool value)
    {
        _isWalking.Value = value;
    }
}
