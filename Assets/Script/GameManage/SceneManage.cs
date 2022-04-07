using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;
using UnityEngine.UI;


public class SceneManage : MonoBehaviour
{
    [SerializeField] PlayerWindow _playerWin;
    [SerializeField] EnemyWindow _enemyWin;
    [SerializeField] GameObject _GameOverView;

    SceneChange _sceneChange = new SceneChange();

    [SerializeField] float fadeOutTime = 6.0f;  //フェードアウトの開始タイミング(秒)
    private float nowTime = 0.0f;     //タイミングカウント用
    public GameObject panel;          //フェードアウト用パネルUIオブジェクト
    private Image image;              //panelのコンポーネント
    private Color color;              //panelのカラー設定


    bool playDeathFlag = false;


    void Start()
    {
        //ボスが死んだらクリア
       // _enemyWin.OnDeath.Subscribe(_ => _sceneChange.ChangeSceneClear());

        //プレイヤーが死んだらアニメーション再生
        _playerWin.OnDeath.Subscribe(_ => playDeathFlag = true);
        this.UpdateAsObservable().Where(_ => (playDeathFlag == true)).Subscribe(_ => GameOverAnim());

        //フェードアウト用のパラメータ取得
        image = panel.GetComponent<Image>();
        color = image.color;

    }

    void GameOverAnim()
    {
        nowTime += Time.deltaTime;

        if (fadeOutTime < nowTime)
        {
            //フェードアウトが終わったらシーン遷移させる
            if (color.a == 2.0f)
            {
                _GameOverView.SetActive(true);
            }
            //アルファ値が1を超過する場合は丸め込む
            else if (color.a + Time.deltaTime > 1.5f)
            {
                color.a = 2.0f;
            }
            //アルファ値を加算する
            else
            {
                color.a += Time.deltaTime;
            }
            image.color = color;
        }
    }


}
