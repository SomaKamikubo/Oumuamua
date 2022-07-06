using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController :CharactorController
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] protected AnimatorView _playerAnimatorView;
    bool _canJump = false;
    ReactiveProperty<bool> _canCrouch = new ReactiveProperty<bool>(true);
    protected virtual void Awake()
    {
        _animatorView = _playerAnimatorView;
        _charactorWindow = _playerWindow;
    }

    protected override void Start() {
        base.Start();
        //_walkChangeList‚ÌƒŠƒXƒg‚É‚¢‚ê‚é
        //‚µ‚á‚ª‚ñ‚Å‚¢‚é‚Æ‚«‚Í•à‚¯‚È‚¢
        _walkChangeList.Add(_canCrouch);

        _playerWindow.OnChangeIsJumping.Subscribe(value => { _canJump = !value; });
        _canAttack.Subscribe(value => { _canJump = value; });
    }


    public void Crounch(bool value)
    {
        //can‚Ì‚½‚ß‚µ‚á‚ª‚ñ‚Å‚¢‚éŠÔ‚Ífalse‚É‚È‚é
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
                if (_canJump)
                {
                    _playerWindow.Jump();
                    _canJump = false;
                    _animatorView.StartCoroutine("PlayAnimation", "JumptoFall");
                }
                break;
            
        }
    }


}
