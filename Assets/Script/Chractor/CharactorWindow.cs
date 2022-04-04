using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CharactorWindow : MonoBehaviour
{
    protected CharactorStatus _charactorStatus;
    protected CharactorHP _charactorHP;
    protected CharactorMove _charactorMove;
    protected CharactorAttack _charactorAttack;
    
    //�L�����N�^�[�̃X�e�[�^�X
    public int getHp(){ return _charactorHP.getHp(); }
    public int getATK() { return _charactorStatus.getATK(); }
    public int getWalkSpeed() { return _charactorStatus.getWalkSpeed(); }


    //move������炢�󂯂�����
    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    //attack������炢�󂯂�����
    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }


    //HP����
    Subject<string> _isDeath = new Subject<string>();
    Subject<string> _isHurt = new Subject<string>();
    public IObservable<string> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }

    //�L�����N�^�[�������\�b�h����
    public void Walk(float amount) { _charactorMove.Walk(amount); }
    public void Attack() { _charactorAttack.Attack(); }
    
    
    protected void CharactorEvent()
    {
        //Move��bool���󂯎��
        _charactorMove.OnChangeIsWalking.Subscribe(value => {_isWalking.Value = value;});

        //attack����̃C�x���g���󂯎��
        _charactorAttack.OnAttack.Subscribe(value => { _isAttacking.OnNext(value); });

        //Hp����̃C�x���g
        _charactorHP.OnHurt.Subscribe(value => { _isHurt.OnNext(value); });
        _charactorHP.OnDeath.Subscribe(value => { _isDeath.OnNext(value); });
    }




}
