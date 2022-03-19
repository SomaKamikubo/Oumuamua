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

    private void Start()
    {
        _noticePlayer.OnFoundPlayer.Subscribe(_isFoundPlayer => {
            //if (_isFoundPlayer)
            //{
            //    _enemyModel.Move(player_posiotion
            //}
        }
        );
    }
}
