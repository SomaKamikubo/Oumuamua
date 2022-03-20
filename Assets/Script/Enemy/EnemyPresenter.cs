using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class EnemyPresenter : MonoBehaviour
{

   // [SerializeField] EnemyView input_view;
    [SerializeField] NoticePlayer _noticePlayer;
    //[SerializeField] EnemyStatus ES;
    [SerializeField] EnemyModel _enemyModel;
    [SerializeField] EnemyReverse _enemyReverse;
    [SerializeField] EnemyView _enemyView;

    private void Start()
    {
        //_noticePlayer.OnFoundPlayer.Subscribe(PlayerPosX => {
        //    //StartCoroutine("SeeKPlayer", PlayerPosX);
        //    _enemyModel.Seek_Player(PlayerPosX);
        //    Debug.Log("プレイヤーの位置が更新された");
        //}

        //正面のコライダーからmodelへ
        _enemyReverse.OnCollideStage.Subscribe(_ => _enemyModel.Reverse());

        //modelからviewへ
        _enemyModel.OnChangeIsWalking.Subscribe(value => { _enemyView.SetAnimator("IsWalking", value); });

    }
}
