using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

//プレイヤーの動きを実装するクラス
public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] int _walkSpeed;
    [SerializeField] int _dashSpeed;
    [SerializeField] int JumpForce;
    bool isMoving;
    bool _preparationDash;

    ReactiveProperty<bool> _isJumping = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isFalling = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isCrouching = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isDashing = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsJumping { get { return _isJumping; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsFalling { get { return _isFalling; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsDashing { get { return _isDashing; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsCrouching { get { return _isCrouching; } }




    //[SerializeField] bool isCrouching;
    int _speed;

    void Start()
    {
        _speed = 0;
        //this.UpdateAsObservable()
        //    .Where(_ => rb.velocity.y < -0.5f)
        //    .Subscribe(_ => { Debug.Log("おちた。" + rb.velocity.y); 　SetIsFalling(true);  });
        
    }



    public void Move(float amount)
    {
        if (amount == 0)
        {
            //Debug.Log("動いていない");
            SetIsWalking(false);
            return;
            
        }
        if (_isCrouching.Value)
        {
            //時間あるときにやろうかな
            //Sliding();
            return;
        }
        if (_preparationDash)
        {
            //Debug.Log("dash");
            _speed = _dashSpeed;
            SetIsDashing(true);
        }
        else
        {
            _speed = _walkSpeed;
            SetIsWalking(true);
        }
        _rb.velocity = new Vector2(amount * _speed, _rb.velocity.y);

    }
    public void receiveShift(bool isPressShift)
    {
        //Debug.Log("mreceiveShift");
        _preparationDash = isPressShift;
        if (isPressShift == false)
        {
            SetIsDashing(false);
        }
    }
    public void Jump()
    {
        if (!_isJumping.Value)
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            SetIsJumping(true);
        }
    }

    public void Crounch(bool value)
    {
        SetIsCrouching(value);
    }

    public void Sliding()
    {
        GetComponent<Animator>().SetTrigger("SlideTrigger");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Stage"))
        {
            Debug.Log("着地した。");
            SetIsJumping(false);
            SetIsFalling(false);
        }
    }

    

    void SetIsJumping(bool value)
    {
        _isJumping.Value = value;
        //Debug.Log("ジャンプ:"+value);
    }
    void SetIsFalling(bool value)
    {
        _isFalling.Value = value;
        //Debug.Log(value);
    }
    void SetIsCrouching(bool value)
    {
        _isCrouching.Value = value;
    }
    void SetIsDashing(bool value)
    {
        _isDashing.Value = value;
        //Debug.Log("Dash:" + value);
    }
    void SetIsWalking(bool value)
    {
        _isWalking.Value = value;
        //Debug.Log("歩く:" + value);
    }

    public bool IsMoving { get { return isMoving; } }
    public bool IsWalking { get { return _isWalking.Value; } }
    public bool IsDashing { get { return _isDashing.Value; } }
    public bool IsJumping { get { return _isJumping.Value; } }
    public bool IsFalling { get { return _isFalling.Value; } }
    public bool IsCrouching { get { return _isCrouching.Value; } }
}
