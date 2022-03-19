using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

//Player自身のこと（おもにHPや攻撃力関すること）
public class Player : MonoBehaviour,IApplyDamage
{
    [SerializeField] int _hp;
    [SerializeField] int _atk;


    Subject<string> _isDeath = new Subject<string>();
    Subject<string> _isHurt = new Subject<string>();
    public IObservable<string> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }


    bool isZero()
    {
        return this._hp == 0;
    }

    public void Damage(int enemy_atk)
    {
        _isHurt.OnNext("HurtTrigger");
        this._hp -= enemy_atk;
        if(this._hp <= 0)
        {
            _isDeath.OnNext("DeathTrigger");
        }
    }

    public void Heal(int heal)
    {
        this._hp += heal;
    }

    //プロパティつかえ()
    public int getATK()
    {
        return _atk;
    }
    public int getHP()
    {
        return _hp;
    }
}
