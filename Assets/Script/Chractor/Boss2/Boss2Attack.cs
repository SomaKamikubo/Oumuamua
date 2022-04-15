using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Boss2Attack :EnemyAttack
{
    [SerializeField] GameObject _player;
    [SerializeField] protected Boss2AttackCollider _boss2AttackCollider;

    Vector3 _playPos;


    ReactiveProperty<bool> _isChasing = new ReactiveProperty<bool>(false);
    public IReadOnlyReactiveProperty<bool> OnChasing { get { return _isChasing; } }
    protected void Awake()
    {
        _attackCollider = _boss2AttackCollider;
    }

    public override void Attack()
    {
        _isChasing.Value = true;
        
        StartCoroutine("TimeCount", 3f);
        StartCoroutine("DelayAttack");
        

    }

    IEnumerator DelayAttack()
    {
        while (_isChasing.Value)
        {
            _playPos = _player.transform.position;
            _boss2AttackCollider.ColliderMove(_playPos);
            yield return new WaitForSeconds(0.1f);
        }

    }
    IEnumerator TimeCount(float time)
    {
        yield return new WaitForSeconds(time);
        _isChasing.Value = false;
        base.Attack();


    }

}
