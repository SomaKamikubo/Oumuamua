using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

//�v���C���[�̍U������������N���X
public class PlayerAttack : MonoBehaviour
{

    PlayerStatus _playerStatus;

    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }
    public void Attack()
    {
        if (_playerStatus.IsDashing)
        {
            _isAttacking.OnNext("DashAttackTrigger");
            return;
        }
        _isAttacking.OnNext("AttackTrigger");

    }





}
