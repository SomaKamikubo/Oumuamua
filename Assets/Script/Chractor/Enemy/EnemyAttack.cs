using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : CharactorAttack
{
    [SerializeField] GameObject _enemyAttackCollider;

    private void Start()
    {
        _attackCollider = _enemyAttackCollider;
    }
}
