using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class EnemyController : CharactorController
{
    [SerializeField] EnemyWindow _enemyWindow;
    [SerializeField] protected AnimatorView _enemyAnimatorView;
    protected virtual void Awake()
    {
        _animatorView = _enemyAnimatorView;
        _charactorWindow = _enemyWindow;

    }

}


