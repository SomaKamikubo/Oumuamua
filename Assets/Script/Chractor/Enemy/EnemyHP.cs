using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : CharactorHP 
{
    [SerializeField] EnemyStatus _enemyStatus;

    protected void Awake()
    {
        _charactorStatus = _enemyStatus;
    }

    public override void Death()
    {
        base.Death();
        Destroy(gameObject, 3f);
    }
}
