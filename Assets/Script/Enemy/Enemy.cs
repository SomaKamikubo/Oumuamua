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
        Debug.Log("HP��" + _hp + "�ɂȂ���");
        if (this._hp <= 0)
        {
            _isDeath.OnNext(true);
        }
    }

    //�v���p�e�B����()
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

    //�����ɐ����͂��邪�E�ɐ����͂Ȃ�
    //�|�����ɃX���[����Ƃ����ƒǂ��Ă���
    public float getEnableMovement()
    {
        return _position.x - _enableDist;
    }
}
