using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    // �Ȃ̒����͌��܂��Ă���Ɖ���
    public readonly float MusicLength = 3f;

    //public PlayerStateEvent OnPlayerStateChanged = new PlayerStateEvent();
    public BoolEvent OnLoopChanged = new BoolEvent();
    public FloatEvent OnPlaybackTimeChanged = new FloatEvent();

    private PlayerState _playerState;
    private float _playbackTime;
    private bool _isLoop = true;

    // �����܂ŗ�Ƃ��Ă̎����Ȃ̂ŁA�{���ɉ��y���Đ�����̂ł͂Ȃ��Đ����Ԃ����Z���邾��
    private void Update()
    {
        if (_playerState == PlayerState.Playing)
        {
            _playbackTime += Time.deltaTime;

            // �Đ����Ԃ��Ȃ̒����𒴂����Ƃ�
            if (MusicLength < _playbackTime)
            {
                if (_isLoop)
                {
                    _playbackTime = 0f;
                }
                else
                {
                    _playbackTime = MusicLength;
                    Stop();
                }
            }

            OnPlaybackTimeChanged.Invoke(_playbackTime);
        }
    }

    public void Play()
    {
        _playerState = PlayerState.Playing;
        //OnPlayerStateChanged.Invoke(_playerState);
    }

    public void Stop()
    {
        _playerState = PlayerState.Stopped;
        //OnPlayerStateChanged.Invoke(_playerState);
    }

    public void SetLoop(bool isLoop)
    {
        _isLoop = isLoop;
        OnLoopChanged.Invoke(_isLoop);
    }
}



public enum PlayerState
{
    Stopped,
    Playing
}
