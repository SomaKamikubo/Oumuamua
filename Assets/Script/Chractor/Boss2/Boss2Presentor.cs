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


    //�߂�ǂ������̂ł������Ɂiwindow�ɏ����܂��傤�j
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

        
        _enemyWindow.OnAttack.Subscribe(_ => _attackAnimatorView.SetAnimatorTrigger("AttackTrigger"));
        _ba2.OnChasing.Subscribe(value => { _animatorView.SetAnimator("IsChase", value); _attackAnimatorView.SetAnimator("IsChase", value); });

    }
}
