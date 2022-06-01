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
    [SerializeField] protected float _startCollide;
    [SerializeField] protected float _finishCollide;
    [SerializeField] protected AttackCollider _attackCollider;
    protected Subject<Unit> _isAttacking = new Subject<Unit>();
    public IObservable<Unit> OnAttack { get { return _isAttacking; } }


    //�A�^�b�N�C�x���g�𔭉΂����R���C�_�[��On�ɂ���
    public virtual void Attack()
    {
        _isAttacking.OnNext(Unit.Default);
        //�����蔻��̒���
        Invoke("ColliderSet", _startCollide);
        Invoke("ColliderReset",_finishCollide);

    }

    protected void ColliderSet()
    {
        _attackCollider.ColliderOn();

    }

    //�R���C�_�[�����Z�b�g
    protected void ColliderReset()
    {
        _attackCollider.ColliderOff();
    }
}
