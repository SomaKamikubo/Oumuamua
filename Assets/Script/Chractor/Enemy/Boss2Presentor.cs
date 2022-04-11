using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class Boss2Presentor :CharactorPresentor
{
    [SerializeField] EnemyWindow _enemyWindow;
    [SerializeField] AnimatorView _enemyAnimatorView;
    [SerializeField] Boss2Input _boss2input;
    [SerializeField] EnemyHPVer _ehb;
    [SerializeField] VsBoss _vsBossTrig;
    [SerializeField] SE _se;

    protected void Awake()
    {
        _animatorView = _enemyAnimatorView;
        _charactorWindow = _enemyWindow;
        _charactorInput = _boss2input;
    }
    protected override void Start()
    {
        base.Start();

        //HPƒo[‚Ì•\Ž¦
        _enemyWindow.OnHurt.Subscribe(_ => { _ehb.HPbar(); _se.playSE(2); });


    }
}
