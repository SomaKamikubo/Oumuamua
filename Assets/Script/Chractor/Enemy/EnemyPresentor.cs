using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyPresentor : CharactorPresentor 
{
    [SerializeField] EnemyWindow _enemyWindow;
    [SerializeField] AnimatorView _enemyAnimatorView;
    [SerializeField] EnemyController _enemyController;
    [SerializeField] EnemyHPVer _ehb;


    protected void Awake()
    {
        _animatorView = _enemyAnimatorView;
        _charactorWindow = _enemyWindow;
        _charactorInput = _enemyController;
    }
    protected override void Start()
    {
        base.Start();
        _enemyWindow.OnHurt.Subscribe(_ => _ehb.HPbar());
    }





}
    

