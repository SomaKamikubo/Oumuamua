using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/*
 * Model
 * キャラクターのHPを管理するクラス
 * HPをステータスから参照し回復やダメージを受けた際の処理を実行
 */
public abstract class CharactorHP : MonoBehaviour,IApplyDamage
{
    [SerializeField] SpriteRenderer sp;
    protected CharactorStatus _charactorStatus;

    //ダメージを受けたときと死んだときのイベント
    Subject<string> _isDeath = new Subject<string>();
    Subject<string> _isHurt = new Subject<string>();
    Subject<string> _isHeal = new Subject<string>();
    public IObservable<string> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }
    public IObservable<string> OnHeal { get { return _isHeal; } }

    protected bool _damaging = false;
    int _nowHp;
    int _maxHp;

    protected virtual void Start()
    {
        //ゲーム開始時にHPを参照する
        _maxHp = _charactorStatus.getMaxHp();
        _nowHp = _maxHp;

    }


    bool isDeath()
    {
        return _nowHp <= 0;
    }

    public void Damage(int enemy_atk)
    {
        //Debug.Log("攻撃された");
        //ダメージを受けているときは攻撃を受けない
        //死んだ後に攻撃を受けないようにする
        if (!_damaging && !isDeath())
        {
            _nowHp -= enemy_atk;
            _isHurt.OnNext("HurtTrigger");

            //点滅させる
            StartCoroutine("Blinking");
            StartCoroutine("CountSecoond", 2.0f);
            if (isDeath())
                Death();
        }
        
    }

    public virtual void Death()
    {
        _isDeath.OnNext("DeathTrigger");//Triggerを直接指定するのはいかがなものか
    }

    public void Heal(int heal)
    {   
        _nowHp += heal;
        if (_nowHp > _maxHp)
            _nowHp = _maxHp;
        _isHeal.OnNext("Test");
    }



    public int getHp() { return _nowHp; }
    public void setHp(int hp) {_nowHp = hp; }

    IEnumerator Blinking()
    {
        _damaging = true;
        while (_damaging)
        {
            yield return new WaitForSeconds(0.1f);
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);
            //Debug.Log("点滅中");
        }
        sp.color = new Color(1f, 1f, 1f, 1);
    }

    IEnumerator CountSecoond(float count)
    {
        yield return new WaitForSeconds(count);
        _damaging = false;
    }
}
