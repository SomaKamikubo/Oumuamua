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
    public int getMaxHp(){ return _charactorHP.getHp(); }
    public int getATK() { return _charactorStatus.getATK(); }
    public int getWalkSpeed() { return _charactorStatus.getWalkSpeed(); }
    public int getHp() { return _charactorHP.getHp(); }


    //---------------------------------------
    //moveからもらい受けたもの
    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    //attackからもらい受けたもの
    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }

    //HPから
    Subject<string> _isDeath = new Subject<string>();
    Subject<string> _isHurt = new Subject<string>();
    public IObservable<string> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }

    //--------------------------------------
    //キャラクターが持つメソッドたち
    public void Walk(float amount) { _charactorMove.Walk(amount); }
    public void Attack() { _charactorAttack.Attack(); }
    
    
    protected virtual void Start()
    {
        //Moveのboolを受け取る
        _charactorMove.OnChangeIsWalking.Subscribe(value => {_isWalking.Value = value;});

        //attackからのイベントを受け取る
        _charactorAttack.OnAttack.Subscribe(value => { _isAttacking.OnNext(value); });

        //Hpからのイベント
        _charactorHP.OnHurt.Subscribe(value => { _isHurt.OnNext(value); });
        _charactorHP.OnDeath.Subscribe(value => { _isDeath.OnNext(value); });
    }




}
