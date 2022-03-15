using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public sealed class Presenter : MonoBehaviour
{
    [SerializeField] private Model _model;
    [SerializeField] private View _view;


    private void Awake()
    {
        // �Ȃ̒���(���f���������Ă���f�[�^)��View�ɃZ�b�g����
        _view.SetMusicLength(_model.MusicLength);

        #region Model��View

        // ���f���̃f�[�^���ω�������A�r���[�ɓ`����
        _model.OnPlaybackTimeChanged.AddListener(playbackTime => _view.SetPlaybackTime(playbackTime));
        //_model.OnPlayerStateChanged.AddListener(state => _view.TogglePlayStopButton(state != PlayerState.Playing));
        _model.OnLoopChanged.AddListener(isOn => _view.SetLoopToggle(isOn));

        #endregion

        #region View��Model

        // �r���[���ω�������A���f���ɓ`����
        _view.OnPlayButtonClicked.AddListener(() => _model.Play());
        _view.OnStopButtonClicked.AddListener(() => _model.Stop());
        _view.OnLoopToggleChanged.AddListener(isOn => _model.SetLoop(isOn));

        #endregion
    }
}

