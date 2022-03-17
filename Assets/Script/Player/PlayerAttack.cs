using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

//プレイヤーの攻撃を実装するクラス
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Player player;

    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }
    public void Attack()
    {
        _isAttacking.OnNext("AttackTrigger");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IApplyDamage>()?.Damage(player.getATK());
    }





}
