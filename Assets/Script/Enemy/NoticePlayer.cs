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


    //���G�͈͂Ƀv���C���[������ꍇ�v���C���[�̂����W�𑗂�
    //���ꂾ�ƃv���C���[�����������Ƃ��ɑΉ��ł��Ȃ�
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        _playerPosX.Value = collision.gameObject.transform.position.x;
    //    }
    //    //Debug.Log("�v���C���[���m���I");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _moveStart.OnNext(Unit.Default);
        }
        //Debug.Log("�v���C���[���m���I");
    }
}
