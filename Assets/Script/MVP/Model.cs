using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    // ‹È‚Ì’·‚³‚ÍŒˆ‚Ü‚Á‚Ä‚¢‚é‚Æ‰¼’è
    public readonly float MusicLength = 3f;

    //public PlayerStateEvent OnPlayerStateChanged = new PlayerStateEvent();
    public BoolEvent OnLoopChanged = new BoolEvent();
    public FloatEvent OnPlaybackTimeChanged = new FloatEvent();

    private PlayerState _playerState;
    private float _playbackTime;
    private bool _isLoop = true;

    // ‚ ‚­‚Ü‚Å—á‚Æ‚µ‚Ä‚ÌÀ‘•‚È‚Ì‚ÅA–{“–‚É‰¹Šy‚ğÄ¶‚·‚é‚Ì‚Å‚Í‚È‚­Ä¶ŠÔ‚ğ‰ÁZ‚·‚é‚¾‚¯
    private void Update()
    {
        if (_playerState == PlayerState.Playing)
        {
            _playbackTime += Time.deltaTime;

            // Ä¶ŠÔ‚ª‹È‚Ì’·‚³‚ğ’´‚¦‚½‚Æ‚«
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
