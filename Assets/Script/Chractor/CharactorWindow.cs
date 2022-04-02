using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CharactorWindow : MonoBehaviour
{
    protected CharactorStatus _charactorStatus;
    protected CharactorHP _charactorHP;
    protected CharactorMove _charactorMove;
    protected CharactorAttack _charactorAttack;
    
    //キャラクターのステータス
    public int getHp(){ return _charactorHP.getHp(); }
    public int getATK() { return _charactorStatus.getATK(); }
    public int getWalkSpeed() { return _charactorStatus.getWalkSpeed(); }


    //moveからもらい受けたもの
    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    //attackからもらい受けたもの
    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }

    //キャラクターが持つメソッドたち
    public void Walk(float amount) { _charactorMove.Walk(amount); }
    public void Attack() { _charactorAttack.Attack(); }
    
    
    protected void CharactorEvent()
    {
        //Moveのboolを受け取る
        _charactorMove.OnChangeIsWalking.Subscribe(value => {_isWalking.Value = value; Debug.Log(value); });

        //attackからのイベントを受け取る
        _charactorAttack.OnAttack.Subscribe(value => { _isAttacking.OnNext(value); Debug.Log("kougeki"); });
    }




}
