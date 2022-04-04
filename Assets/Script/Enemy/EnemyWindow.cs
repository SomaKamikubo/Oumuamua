using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWindow : CharactorWindow
{
    [SerializeField] EnemyStatus _enemyStatus;
    [SerializeField] EnemyHP _enemyHP;
    [SerializeField] EnemyMove _enemyMove;
    [SerializeField] EnemyAttack _enemyAttack;
    private void Awake()
    {
        _charactorAttack = _enemyAttack;
        _charactorMove = _enemyMove;
        _charactorStatus = _enemyStatus;
        _charactorHP = _enemyHP;
        CharactorEvent();
    }
}
