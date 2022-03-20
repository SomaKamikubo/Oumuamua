using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Enemy : MonoBehaviour, IApplyDamage
{
    [SerializeField] int _maxHp;
    [SerializeField] int _atk;
    [SerializeField] int _enableDist;
    [SerializeField] Rigidbody2D _rb;
    int _hp;
    Vector3 _position;

    Subject<string> _isDeath = new Subject<string>();
    Subject<string> _isHurt = new Subject<string>();
    public IObservable<string> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }

    void Start()
    {
        _position = transform.position;
    }
    public void Initialized()
    {
        this._hp = _maxHp;
        transform.position = _position;
    }

    public void Damage(int player_atk)
    {
        _isHurt.OnNext("HurtTrigger");
        this._hp -= player_atk;
        if (this._hp <= 0)
        {
            _isDeath.OnNext("DeathTrigger");
        }
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

    public Vector3 getFirstPosition()
    {
        return _position;
    }

    //左側に制限はあるが右に制限はない
    //倒さずにスルーするとずっと追ってくる
    public float getEnableMovement()
    {
        return _position.x - _enableDist;
    }
}
