using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class PlayerController :CharactorController
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] protected AnimatorView _playerAnimatorView;
    ReactiveProperty<bool> _canJump = new ReactiveProperty<bool>(true);
    ReactiveProperty<bool> _canCrouch = new ReactiveProperty<bool>(true);
    protected List<ReactiveProperty<bool>> _jumpChangeList = new List<ReactiveProperty<bool>>();
    List<ReactiveProperty<bool>> _dashChangeList = new List<ReactiveProperty<bool>>();
    protected virtual void Awake()
    {
        _animatorView = _playerAnimatorView;
        _charactorWindow = _playerWindow;

        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.Q))
            .Subscribe(_ => {
                

            });
    }

    protected override void Start() {
        base.Start();
        //_walkChangeListのリストにいれる
        //しゃがんでいるときは歩けない
        _walkChangeList.Add(_canCrouch);

        //以下の動作中にジャンプできない
        _jumpChangeList.Add(_canAttack);　//攻撃
        _jumpChangeList.Add(_canCrouch);　//しゃがみ
        _jumpChangeList.Add(_canJump);  //ジャンプ

        //以下の動作中に攻撃できない
        _attackChangeList.Add(_canJump); //ジャンプ
        _attackChangeList.Add(_canCrouch); //しゃがみ

        //ジャンプ中に攻撃できない
        _dashChangeList.Add(_canJump);

        _playerWindow.OnChangeIsGraunding.Subscribe(value => {
            _canJump.Value = value;
            //Debug.Log("地面イルカ："+value);

        });

    }


    public void Crounch(bool value)
    {
        //canのためしゃがんでいる間はfalseになる
        _canCrouch.Value = !value;
        _playerWindow.Crounch(value);
    }

    public void ControllDash(bool isShift)
    {
        if (isAllTrue(_dashChangeList) || isShift == false)
        {
            _playerWindow.receiveShift(isShift);
        }


    }

    public override void Control(string key)
    {
        base.Control(key);
        switch (key)
        {
            case "Jump":
                //canSwitch();
                if (isAllTrue(_jumpChangeList))
                {
                    _playerWindow.Jump();
                    _canJump.Value = false;
                    _animatorView.StartCoroutine("PlayAnimation", "JumptoFall");
                }
                break;
            
        }
    }


}
