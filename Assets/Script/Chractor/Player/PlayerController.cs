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
        //_walkChangeList�̃��X�g�ɂ����
        //���Ⴊ��ł���Ƃ��͕����Ȃ�
        _walkChangeList.Add(_canCrouch);

        //�ȉ��̓��쒆�ɃW�����v�ł��Ȃ�
        _jumpChangeList.Add(_canAttack);�@//�U��
        _jumpChangeList.Add(_canCrouch);�@//���Ⴊ��
        _jumpChangeList.Add(_canJump);  //�W�����v


        _playerWindow.OnChangeIsGraunding.Subscribe(value => {
            _canJump.Value = value;
        });

    }


    public void Crounch(bool value)
    {
        //can�̂��߂��Ⴊ��ł���Ԃ�false�ɂȂ�
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
