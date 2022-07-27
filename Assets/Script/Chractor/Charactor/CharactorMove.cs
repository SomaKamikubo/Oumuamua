using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
/*
 * Model
 * �L�����N�^�[����������
 */
public abstract class CharactorMove : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    protected CharactorStatus _charactorStatus;
    [SerializeField] protected GameObject patentobject;

    [SerializeField] Vector2 AxisOfRotation; //��]����^�񒆂ɂ��邽��



    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    int _speed = 0;
    Vector3 _scale;

    public virtual void Start()
    {
        _rb.centerOfMass = AxisOfRotation;
    }

    public virtual void Walk(float amount)
    {
        //�L�����N�^�[�̔��]����
        _scale = patentobject.transform.localScale;
        if (amount < 0 && _scale.x > 0 || amount > 0 && _scale.x < 0)
        {
            _scale.x *= -1;
        }
        patentobject.transform.localScale = _scale;

        //���͂��Ȃ��Ȃ瓮���Ȃ�
        if (amount == 0)
        {
            SetIsWalking(false);
            return;
        }

        //����
        _speed = _charactorStatus.getWalkSpeed();
        SetIsWalking(true);
        _rb.velocity = new Vector2(amount* _speed, _rb.velocity.y);
    }


    protected void SetIsWalking(bool value)
    {
        _isWalking.Value = value;
    }

    public void Stop()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);

    }
}
