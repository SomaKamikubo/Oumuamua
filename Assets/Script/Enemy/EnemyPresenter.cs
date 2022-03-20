using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class EnemyPresenter : MonoBehaviour
{
    [SerializeField] NoticePlayer _noticePlayer;
    [SerializeField] Enemy _enemy;
    [SerializeField] EnemyModel _enemyModel;
    [SerializeField] EnemyReverse _enemyReverse;
    [SerializeField] EnemyView _enemyView;

    private void Start()
    {
        //_noticePlayer.OnFoundPlayer.Subscribe(PlayerPosX => {
        //    //StartCoroutine("SeeKPlayer", PlayerPosX);
        //    _enemyModel.Seek_Player(PlayerPosX);
        //    Debug.Log("�v���C���[�̈ʒu���X�V���ꂽ");
        //}

        //���ʂ̃R���C�_�[����model��
        _enemyReverse.OnCollideStage.Subscribe(_ => _enemyModel.Reverse());

        //model����view��
        _enemyModel.OnChangeIsWalking.Subscribe(value => { _enemyView.SetAnimator("IsWalking", value); });

        //_enemy.OnHurt.Subscribe(value => _enemyView.SetAnimatorTrigger(value));
        _enemy.OnDeath.Subscribe(value => { _enemyView.SetAnimator("IsDeath", value); });
        _enemy.OnDeath.Subscribe(value => _enemyModel.Death());

    }
}
