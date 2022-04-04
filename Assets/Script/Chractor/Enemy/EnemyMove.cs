using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove :CharactorMove
{
    [SerializeField] EnemyStatus _enemyStatus;


    void Start()
    {
        _charactorStatus = _enemyStatus;

    }
}
