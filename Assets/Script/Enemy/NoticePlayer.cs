using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class NoticePlayer : MonoBehaviour
{
    ReactiveProperty<float> _isNoticePlayer = new ReactiveProperty<float>(0);

    public IObservable<float> OnFoundPlayer { get { return _isNoticePlayer; } }

   
    //これだとプレイヤーが複数いたときに対応できない
    void OnTriggerStay2D(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isNoticePlayer.Value = other.gameObject.transform.position.x;
        }
    }
}
