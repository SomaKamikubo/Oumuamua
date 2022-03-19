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

   
    void OnTriggerEnter2D(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //_isNoticePlayer.Value = true;
        }
    }

    void OnTriggerExit2D(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //_isNoticePlayer.Value = false;
        }
    }
}
