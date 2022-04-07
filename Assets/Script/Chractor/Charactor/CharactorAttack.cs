using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/*
 * Model
 * キャラクターのアタックに関する処理
 */
public abstract class CharactorAttack : MonoBehaviour
{
    [SerializeField] float _startCollide;
    [SerializeField] float _finishCollide;
    [SerializeField] AttackCollider _attackCollider;
    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }


    //アタックイベントを発火させコライダーをOnにする
    public void Attack()
    {
        _isAttacking.OnNext("AttackTrigger");
        //当たり判定の調整
        Invoke("ColliderSet", _startCollide);
        Invoke("ColliderReset",_finishCollide);

    }

    void ColliderSet()
    {
        _attackCollider.ColliderOn();

    }

    //コライダーをリセット
    void ColliderReset()
    {
        _attackCollider.ColliderOff();
    }
}
