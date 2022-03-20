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

    Subject<bool> _isDeath = new Subject<bool>();
    Subject<string> _isHurt = new Subject<string>();
    public IObservable<bool> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }

    void Start()
    {
        _position = transform.position;
        _hp = _maxHp;
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
        Debug.Log("HPが" + _hp + "になった");
        if (this._hp <= 0)
        {
            _isDeath.OnNext(true);
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
