using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public abstract class CharactorHP : MonoBehaviour,IApplyDamage
{
    protected CharactorStatus _charactorStatus;


    Subject<string> _isDeath = new Subject<string>();
    Subject<string> _isHurt = new Subject<string>();
    public IObservable<string> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }

    protected int _nowHp;

    protected virtual void Start()
    {
        _nowHp = _charactorStatus.getMaxHp();
    }

    //名前変える
    bool isZero()
    {
        return _nowHp <= 0;
    }

    public void Damage(int enemy_atk)
    {
        _nowHp -= enemy_atk;
        
        _isHurt.OnNext("HurtTrigger");
        if (isZero())
        {
            Death();
        }
    }

    public virtual void Death()
    {
        _isDeath.OnNext("DeathTrigger");
    }

    public void Heal(int heal)
    {
        _nowHp += heal;
    }

    public int getHp() { return _nowHp; }
    
}
