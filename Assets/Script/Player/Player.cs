using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class Player : MonoBehaviour,IApplyDamage
{
    [SerializeField]
    int _hp;
    int _atk;


    Subject<string> _isDeath = new Subject<string>();
    Subject<string> _isHurt = new Subject<string>();
    public IObservable<string> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }


    bool isZero()
    {
        return this._hp == 0;
    }

    public void Damage(int atk)
    {
        _isHurt.OnNext("HurtTrigger");
        this._hp -= atk;
        if(this._hp <= 0)
        {
            _isDeath.OnNext("DeathTrigger");
        }
    }

    public void Heal(int heal)
    {
        this._hp += heal;
    }

    public int getATK()
    {
        return _atk;
    }
}
