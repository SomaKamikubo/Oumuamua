using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/*
 * Model
 * �L�����N�^�[�̃A�^�b�N�Ɋւ��鏈��
 */
public abstract class CharactorAttack : MonoBehaviour
{
    [SerializeField] float _startCollide;
    [SerializeField] float _finishCollide;
    [SerializeField] AttackCollider _attackCollider;
    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }


    //�A�^�b�N�C�x���g�𔭉΂����R���C�_�[��On�ɂ���
    public void Attack()
    {
        _isAttacking.OnNext("AttackTrigger");
        //�����蔻��̒���
        Invoke("ColliderSet", _startCollide);
        Invoke("ColliderReset",_finishCollide);

    }

    void ColliderSet()
    {
        _attackCollider.ColliderOn();

    }

    //�R���C�_�[�����Z�b�g
    void ColliderReset()
    {
        _attackCollider.ColliderOff();
    }
}
