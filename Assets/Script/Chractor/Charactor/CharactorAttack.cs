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
    [SerializeField] protected float _startCollide;
    [SerializeField] protected float _finishCollide;
    [SerializeField] protected AttackCollider _attackCollider;
    protected Subject<Unit> _isAttacking = new Subject<Unit>();
    public IObservable<Unit> OnAttack { get { return _isAttacking; } }


    //アタックイベントを発火させコライダーをOnにする
    public virtual void Attack()
    {
        _isAttacking.OnNext(Unit.Default);
        //当たり判定の調整
        Invoke("ColliderSet", _startCollide);
        Invoke("ColliderReset",_finishCollide);

    }

    protected void ColliderSet()
    {
        _attackCollider.ColliderOn();

    }

    //コライダーをリセット
    protected void ColliderReset()
    {
        _attackCollider.ColliderOff();
    }
}
