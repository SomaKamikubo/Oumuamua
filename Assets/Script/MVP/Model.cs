using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    // 曲の長さは決まっていると仮定
    public readonly float MusicLength = 3f;

    //public PlayerStateEvent OnPlayerStateChanged = new PlayerStateEvent();
    public BoolEvent OnLoopChanged = new BoolEvent();
    public FloatEvent OnPlaybackTimeChanged = new FloatEvent();

    private PlayerState _playerState;
    private float _playbackTime;
    private bool _isLoop = true;

    // あくまで例としての実装なので、本当に音楽を再生するのではなく再生時間を加算するだけ
    private void Update()
    {
        if (_playerState == PlayerState.Playing)
        {
            _playbackTime += Time.deltaTime;

            // 再生時間が曲の長さを超えたとき
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
