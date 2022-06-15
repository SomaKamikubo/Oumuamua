using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController :CharactorController
{
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] protected AnimatorView _playerAnimatorView;
   // bool _canJump = false;
   protected virtual void Awake()
    {
        _animatorView = _playerAnimatorView;
        _charactorWindow = _playerWindow;
    }

    protected override void Start() {
        base.Start();
        _playerWindow.OnChangeIsJumping.Subscribe(value => { _canAct = !value; });
    }

    public override void Control(string key)
    {
        base.Control(key);
        switch (key)
        {
            case "Jump":
                if (_canAct)
                {
                    _playerWindow.Jump();
                    _canAct = false;
                    _animatorView.StartCoroutine("PlayAnimation", "JumptoFall");
                }
                break;
        }
    }
}
