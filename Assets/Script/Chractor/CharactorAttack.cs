using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CharactorAttack : MonoBehaviour
{

    [SerializeField] GameObject _attackCollider;

    //TriggerAnimetion _triAni = new TriggerAnimetion();
    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }



    public void Attack()
    {
        //_triAni.AttackAnimation();
        _isAttacking.OnNext("AttackTrigger");
        Debug.Log("attack");
        _attackCollider.GetComponent<CapsuleCollider2D>().enabled = true;
        Invoke("ColliderReset", 0.3f);

    }

    void ColliderReset()
    {
        _attackCollider.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
