using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class PlayerMove : CharactorMove
{
    [SerializeField] PlayerStatus _playerStatus;

    bool _preparationDash;

    ReactiveProperty<bool> _isJumping = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isFalling = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isCrouching = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isDashing = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isGraunding = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsJumping { get { return _isJumping; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsFalling { get { return _isFalling; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsDashing { get { return _isDashing; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsCrouching { get { return _isCrouching; } }
    public IReadOnlyReactiveProperty<bool> OnChangeIsGraunding { get { return _isGraunding; } }

    ReactiveProperty<float> _vectorY = new ReactiveProperty<float>();


    int _moveSpeed = 0;
    Vector3 _tempScale;

    void Start()
    {
        _charactorStatus = _playerStatus;
        this.UpdateAsObservable()
            .Where(_ => _isGraunding.Value == false && _rb.velocity.y < -1.0f)
            .Subscribe(_ => { SetIsFalling(true); });

    }



    public void Move(float amount)
    {

        _tempScale = gameObject.transform.localScale;
        if (amount < 0 && _tempScale.x > 0 || amount > 0 && _tempScale.x < 0)
        {
            _tempScale.x *= -1;
        }
        gameObject.transform.localScale = _tempScale;
        if (amount == 0)
        {
            //Debug.Log("動いていない");
            SetIsWalking(false);
            SetIsDashing(false);
            _rb.velocity = new Vector2(amount * _moveSpeed, _rb.velocity.y);

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
            _moveSpeed = _playerStatus.getDashSpeed();
            SetIsDashing(true);
        }
        else
        {
            //Debug.Log("walk"+amount);
            _moveSpeed = _playerStatus.getWalkSpeed();
            SetIsWalking(true);
        }
        _rb.velocity = new Vector2(amount * _moveSpeed, _rb.velocity.y);

    }

    //walkがうまくいかなかったのでMoveに任せる
    public override void Walk(float amount)
    {
        Move(amount);
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
            _rb.AddForce(Vector2.up * _playerStatus.getJumpPower(), ForceMode2D.Impulse);
            SetIsJumping(true);
        }
    }

    public void Crounch(bool value)
    {
        if (value)
        {
            //ちょっとごり押し過ぎる？
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        SetIsCrouching(value);
    }

    public void Sliding()
    {
        GetComponent<Animator>().SetTrigger("SlideTrigger");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("着地した。");
            SetIsJumping(false);
            SetIsFalling(false);
            _isGraunding.Value = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGraunding.Value = false;
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

    public bool getIsJumping()
    {
        return _isJumping.Value;
    }
}
