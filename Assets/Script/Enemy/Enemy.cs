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
    [SerializeField] SpriteRenderer sp;
    int _hp;
    Vector3 _position;
    bool _temp;//CountSecondで保存されるやつ、使われないときはfalseがはいるので使う前はtrueにする

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
            return;
        }
        StartCoroutine("Damaged");
        StartCoroutine("CountSecoond",2.0f);
        sp.color = new Color(1f, 1f, 1f, 1);
    }

    IEnumerator Damaged()
    {
        _temp = true;
        while (_temp)
        {
            yield return new WaitForSeconds(0.1f);
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);
            //Debug.Log("点滅中");
        }
        
    }

    IEnumerator CountSecoond(float count)
    {
        yield return new WaitForSeconds(count);
        _temp = false;
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
