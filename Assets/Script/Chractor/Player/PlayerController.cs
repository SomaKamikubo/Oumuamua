using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController :CharactorController
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] protected AnimatorView _playerAnimatorView;
    ReactiveProperty<bool> _canJump = new ReactiveProperty<bool>(true);
    ReactiveProperty<bool> _canCrouch = new ReactiveProperty<bool>(true);
    protected List<ReactiveProperty<bool>> _jumpChangeList = new List<ReactiveProperty<bool>>();

    protected virtual void Awake()
    {
        _animatorView = _playerAnimatorView;
        _charactorWindow = _playerWindow;
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


        _playerWindow.OnChangeIsGraunding.Subscribe(value => {
            _canJump.Value = value;
        });

    }


    public void Crounch(bool value)
    {
        //canのためしゃがんでいる間はfalseになる
        _canCrouch.Value = !value;
        _playerWindow.Crounch(value);
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
