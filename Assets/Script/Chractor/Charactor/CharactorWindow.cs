using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
/*
 * �L�����N�^�[�̏����܂Ƃ߂�
 * �L�����N�^�[�̏���m�肽���Ƃ��͂������Q��
 */
public abstract class CharactorWindow : MonoBehaviour
{
    protected CharactorStatus _charactorStatus;
    protected CharactorHP _charactorHP;
    protected CharactorMove _charactorMove;
    protected CharactorAttack _charactorAttack;


    //---------------------------------------
    //�L�����N�^�[�̃X�e�[�^�X
    public int getMaxHp(){ return _charactorStatus.getMaxHp(); }
    public int getATK() { return _charactorStatus.getATK(); }
    public int getWalkSpeed() { return _charactorStatus.getWalkSpeed(); }
    public int getHp() { return _charactorHP.getHp(); }
    public void setHp(int hp) { _charactorHP.setHp(hp); }


    //---------------------------------------
    //move������炢�󂯂�����
    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    //attack������炢�󂯂�����
    Subject<Unit> _isAttacking = new Subject<Unit>();
    public IObservable<Unit> OnAttack { get { return _isAttacking; } }

    //HP����
    Subject<Unit> _isDeath = new Subject<Unit>(); //public�͒v�����Ȃ��B��ŏ���������Bboss�����̋��L�̂��߂Ɏg���Ă���
    Subject<Unit> _isHurt = new Subject<Unit>();
    Subject<Unit> _isHeal = new Subject<Unit>();
    public IObservable<Unit> OnDeath { get { return _isDeath; } }
    public IObservable<Unit> OnHurt { get { return _isHurt; } }
    public IObservable<Unit> OnHeal { get { return _isHeal; } }

    //--------------------------------------
    //�L�����N�^�[�������\�b�h����
    public void Walk(float amount) { _charactorMove.Walk(amount); }
    public void Stop() { _charactorMove.Stop(); }

    public void Attack() { _charactorAttack.Attack(); }
    public void Heal(int heal) { _charactorHP.Heal(heal); }
    public void Damage(int atk) { _charactorHP.Damage(atk); }
    
    
    protected virtual void Start()
    {
        //Move��bool���󂯎��
        _charactorMove.OnChangeIsWalking.Subscribe(value => {_isWalking.Value = value;});

        //attack����̃C�x���g���󂯎��
        _charactorAttack.OnAttack.Subscribe(_ => { _isAttacking.OnNext(Unit.Default); });

        //Hp����̃C�x���g
        _charactorHP.OnDeath.Subscribe(_ => { _isDeath.OnNext(Unit.Default); });
        bool first = true;
        int beforHp = _charactorStatus.getMaxHp();
        _charactorHP.OnChangeHP.Subscribe(nowHp => {
            if (!first)�@//boss2�̃o�O�΍�(�o�ꎞ�ɑ̗͂�0�ɂȂ�)
            {
                if (beforHp <= 0) //���X����ł��珈���͍s��Ȃ�
                    return;

                Debug.Log("����HP:" + nowHp);
                if (nowHp > beforHp)//HP�������Ă�Ȃ�
                    _isHeal.OnNext(Unit.Default);
                else if (nowHp < beforHp )
                {    
                    _isHurt.OnNext(Unit.Default);
                    if (_charactorHP.isDeath())
                    {
                        Debug.Log("����" + nowHp + ":" + beforHp);
                        _isDeath.OnNext(Unit.Default);
                    }
                }

                else
                    Debug.Log("nowHP==beforHP");
                beforHp = nowHp;
               
            }
            else�@//boss2�̃o�O�΍�(�o�ꎞ�ɑ̗͂�0�ɂȂ�)
            {
                first = false;
            }
            
                
            });
    }




}
