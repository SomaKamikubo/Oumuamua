using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : CharactorHP 
{
    [SerializeField] EnemyStatus _enemyStatus;
    private void Start()
    {
        _charactorStatus = _enemyStatus;
    }
}
