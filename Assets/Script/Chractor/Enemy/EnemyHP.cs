using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : CharactorHP 
{
    [SerializeField] EnemyStatus _enemyStatus;
    protected override void Start()
    {
        _charactorStatus = _enemyStatus;
        base.Start();
        
    }
}
