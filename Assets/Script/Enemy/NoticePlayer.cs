using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class NoticePlayer : MonoBehaviour
{
    ReactiveProperty<float> _playerPosX = new ReactiveProperty<float>(0);

    public IObservable<float> OnFoundPlayer { get { return _playerPosX; } }

    Subject<Unit> _moveStart = new Subject<Unit>();
    public IObservable<Unit> OnMoveStart { get { return _moveStart; } }


    //索敵範囲にプレイヤーがいる場合プレイヤーのｘ座標を送る
    //これだとプレイヤーが複数いたときに対応できない
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        _playerPosX.Value = collision.gameObject.transform.position.x;
    //    }
    //    //Debug.Log("プレイヤー検知中！");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _moveStart.OnNext(Unit.Default);
        }
        //Debug.Log("プレイヤー検知中！");
    }
}
