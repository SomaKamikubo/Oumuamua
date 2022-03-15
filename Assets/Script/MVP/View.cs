using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class View : MonoBehaviour
{
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _stopButton;
        [SerializeField] private Toggle _loopToggle;
        [SerializeField] private Slider _seekBar;
        [SerializeField] private Text _playbackTime;

        public UnityEvent OnPlayButtonClicked = new UnityEvent();
        public UnityEvent OnStopButtonClicked = new UnityEvent();
        public BoolEvent OnLoopToggleChanged = new BoolEvent();

        private void Awake()
        {
            // UIが変化(ボタンがクリックされたりトグルが変化したり)したらイベントを発行する
            _playButton.onClick.AddListener(() => OnPlayButtonClicked.Invoke());
            _stopButton.onClick.AddListener(() => OnStopButtonClicked.Invoke());
            _loopToggle.onValueChanged.AddListener(isOn => OnLoopToggleChanged.Invoke(isOn));
        }

        public void SetMusicLength(float musicLength)
        {
            _seekBar.maxValue = musicLength;
        }

        public void TogglePlayStopButton(bool showPlayButton)
        {
            _playButton.gameObject.SetActive(showPlayButton);
            _stopButton.gameObject.SetActive(!showPlayButton);
        }

        public void SetLoopToggle(bool isOn)
        {
            _loopToggle.isOn = isOn;
        }

        public void SetPlaybackTime(float playbackTime)
        {
            _seekBar.value = playbackTime; // シークバーに再生時間をセットする
            //_playbackTime.text = TimeSpan.FromSeconds(playbackTime).ToString(@"ss\:fff"); // 表示用に整形してテキストをセット
        }
   }

