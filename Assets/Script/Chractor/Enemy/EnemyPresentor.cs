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
    [SerializeField] VsBoss _vsBossTrig;
    [SerializeField] SE _se;

    protected void Awake()
    {
        _animatorView = _enemyAnimatorView;
        _charactorWindow = _enemyWindow;
        _charactorInput = _enemyController;
    }
    protected override void Start()
    {
        base.Start();

        //HPバーの表示
        _enemyWindow.OnHurt.Subscribe(_ => { _ehb.HPbar(); _se.playSE(2); });
        _vsBossTrig.VsBossTrigger.Subscribe(_ => { _ehb.SetActive(true); Debug.Log("boss"); });
    }





}
    

