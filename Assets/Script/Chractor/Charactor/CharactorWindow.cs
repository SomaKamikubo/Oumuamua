using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
/*
 * キャラクターの情報をまとめる
 * キャラクターの情報を知りたいときはここを参照
 */
public abstract class CharactorWindow : MonoBehaviour
{
    protected CharactorStatus _charactorStatus;
    protected CharactorHP _charactorHP;
    protected CharactorMove _charactorMove;
    protected CharactorAttack _charactorAttack;


    //---------------------------------------
    //キャラクターのステータス
    public int getMaxHp(){ return _charactorStatus.getMaxHp(); }
    public int getATK() { return _charactorStatus.getATK(); }
    public int getWalkSpeed() { return _charactorStatus.getWalkSpeed(); }
    public int getHp() { return _charactorHP.getHp(); }
    public void setHp(int hp) { _charactorHP.setHp(hp); }


    //---------------------------------------
    //moveからもらい受けたもの
    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    //attackからもらい受けたもの
    Subject<Unit> _isAttacking = new Subject<Unit>();
    public IObservable<Unit> OnAttack { get { return _isAttacking; } }

    //HPから
    Subject<Unit> _isDeath = new Subject<Unit>(); //publicは致し方なく。後で書き換える。bossが死の共有のために使っている
    Subject<Unit> _isHurt = new Subject<Unit>();
    Subject<Unit> _isHeal = new Subject<Unit>();
    public IObservable<Unit> OnDeath { get { return _isDeath; } }
    public IObservable<Unit> OnHurt { get { return _isHurt; } }
    public IObservable<Unit> OnHeal { get { return _isHeal; } }

    //--------------------------------------
    //キャラクターが持つメソッドたち
    public void Walk(float amount) { _charactorMove.Walk(amount); }
    public void Stop() { _charactorMove.Stop(); }

    public void Attack() { _charactorAttack.Attack(); }
    public void Heal(int heal) { _charactorHP.Heal(heal); }
    public void Damage(int atk) { _charactorHP.Damage(atk); }
    
    
    protected virtual void Start()
    {
        //Moveのboolを受け取る
        _charactorMove.OnChangeIsWalking.Subscribe(value => {_isWalking.Value = value;});

        //attackからのイベントを受け取る
        _charactorAttack.OnAttack.Subscribe(_ => { _isAttacking.OnNext(Unit.Default); });

        //Hpからのイベント
        _charactorHP.OnDeath.Subscribe(_ => { _isDeath.OnNext(Unit.Default); });
        bool first = true;
        int beforHp = _charactorStatus.getMaxHp();
        _charactorHP.OnChangeHP.Subscribe(nowHp => {
            if (!first)　//boss2のバグ対策(登場時に体力が0になる)
            {
                if (beforHp <= 0) //元々死んでたら処理は行わない
                    return;

                Debug.Log("現在HP:" + nowHp);
                if (nowHp > beforHp)//HPが増えてるなら
                    _isHeal.OnNext(Unit.Default);
                else if (nowHp < beforHp )
                {    
                    _isHurt.OnNext(Unit.Default);
                    if (_charactorHP.isDeath())
                    {
                        Debug.Log("死んだ" + nowHp + ":" + beforHp);
                        _isDeath.OnNext(Unit.Default);
                    }
                }

                else
                    Debug.Log("nowHP==beforHP");
                beforHp = nowHp;
               
            }
            else　//boss2のバグ対策(登場時に体力が0になる)
            {
                first = false;
            }
            
                
            });
    }




}
