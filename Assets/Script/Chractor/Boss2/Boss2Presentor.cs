using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class Boss2Presentor :CharactorPresentor
{
    [SerializeField] EnemyWindow _enemyWindow;
    [SerializeField] AnimatorView _enemyAnimatorView;
    [SerializeField] AnimatorView _attackAnimatorView;
    [SerializeField] Boss2Input _boss2input;
    [SerializeField] EnemyHPVer _ehb;
    [SerializeField] SE _se;

    //めんどくさいのでこっちに（windowに書きましょう）
    [SerializeField] Boss2Attack _ba2;

    protected void Awake()
    {
        _animatorView = _enemyAnimatorView;
        _charactorWindow = _enemyWindow;
        _charactorInput = _boss2input;
    }
    protected override void Start()
    {
        base.Start();

        //HPバーの表示
        _enemyWindow.OnHurt.Subscribe(_ => { _ehb.HPbar(); _se.playSE(2); });
        _enemyWindow.OnAttack.Subscribe(value => _attackAnimatorView.SetAnimatorTrigger(value));
        _ba2.OnChasing.Subscribe(value => { _animatorView.SetAnimator("IsChase", value); _attackAnimatorView.SetAnimator("IsChase", value); });

    }
}
