using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPresentor : CharactorPresentor 
{
    [SerializeField] EnemyWindow _enemyWindow;
    [SerializeField] AnimatorView _enemyAnimatorView;
    [SerializeField] EnemyController _enemyController;


    protected void Awake()
    {
        _animatorView = _enemyAnimatorView;
        _charactorWindow = _enemyWindow;
        _charactorInput = _enemyController;
    }

    

    
    
}
    

