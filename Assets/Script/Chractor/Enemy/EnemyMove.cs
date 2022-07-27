using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove :CharactorMove
{
    [SerializeField] EnemyStatus _enemyStatus;


    public override void Start()
    {
        base.Start();
        _charactorStatus = _enemyStatus;

    }
}
