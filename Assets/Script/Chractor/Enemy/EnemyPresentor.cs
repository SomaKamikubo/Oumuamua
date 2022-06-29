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
    [SerializeField] SE _se;
    [SerializeField] EnemyInput _enemyInput;

    protected void Awake()
    {
        _animatorView = _enemyAnimatorView;
        _charactorWindow = _enemyWindow;
        _charactorController = _enemyController;
    }
    protected override void Start()
    {
        base.Start();

        //HPƒo[‚Ì•\Ž¦
        _enemyWindow.OnHurt.Subscribe(_ => { _ehb.HPbar(); _se.playSE(2); });
        _enemyWindow.OnHeal.Subscribe(_ => { _ehb.HPbar();});
    }





}
    

