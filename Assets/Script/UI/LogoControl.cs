using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogoControl : MonoBehaviour
{

    public float soundTime = 1.0f;    //音声再生の開始タイミング(秒)
    public float fadeOutTime = 6.0f;  //フェードアウトの開始タイミング(秒)
    private float nowTime = 0.0f;     //タイミングカウント用

    public GameObject panel;          //フェードアウト用パネルUIオブジェクト
    private Image image;              //panelのコンポーネント
    private Color color;              //panelのカラー設定
    private AudioSource audioSource;  //音声再生用のオーディオソース
    private bool soundFlg = false;    //音声再生用フラグ

    void Start()
    {
        //音声再生用のオーディオソース取得
        audioSource = GetComponent<AudioSource>();

        //フェードアウト用のパラメータ取得
        image = panel.GetComponent<Image>();
        color = image.color;
    }

    void Update()
    {
        //deltaTimeを加算して経過時間を計算する
        nowTime += Time.deltaTime;

        //指定の秒数が経過した際、1度だけ音声を再生する
        if (soundTime < nowTime && soundFlg == false)
        {
            audioSource.Play();
            soundFlg = true;
        }

        //指定の秒数が経過した際、フェードアウトしてシーンを遷移する
        if (fadeOutTime < nowTime)
        {
            //フェードアウトが終わったらシーン遷移させる
            if (color.a == 2.0f)
            {
                SceneManager.LoadScene("Title");
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