using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

//�v���C���[�̍U������������N���X
public class PlayerAttack : CharactorAttack
{


    [SerializeField] GameObject _playerAttackCollider;

    private void Start()
    {
        _attackCollider = _playerAttackCollider;
    }

}
