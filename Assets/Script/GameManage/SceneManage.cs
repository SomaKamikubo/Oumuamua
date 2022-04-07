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

    [SerializeField] float fadeOutTime = 6.0f;  //�t�F�[�h�A�E�g�̊J�n�^�C�~���O(�b)
    private float nowTime = 0.0f;     //�^�C�~���O�J�E���g�p
    public GameObject panel;          //�t�F�[�h�A�E�g�p�p�l��UI�I�u�W�F�N�g
    private Image image;              //panel�̃R���|�[�l���g
    private Color color;              //panel�̃J���[�ݒ�


    bool playDeathFlag = false;


    void Start()
    {
        //�{�X�����񂾂�N���A
       // _enemyWin.OnDeath.Subscribe(_ => _sceneChange.ChangeSceneClear());

        //�v���C���[�����񂾂�A�j���[�V�����Đ�
        _playerWin.OnDeath.Subscribe(_ => playDeathFlag = true);
        this.UpdateAsObservable().Where(_ => (playDeathFlag == true)).Subscribe(_ => GameOverAnim());

        //�t�F�[�h�A�E�g�p�̃p�����[�^�擾
        image = panel.GetComponent<Image>();
        color = image.color;

    }

    void GameOverAnim()
    {
        nowTime += Time.deltaTime;

        if (fadeOutTime < nowTime)
        {
            //�t�F�[�h�A�E�g���I�������V�[���J�ڂ�����
            if (color.a == 2.0f)
            {
                _GameOverView.SetActive(true);
            }
            //�A���t�@�l��1�𒴉߂���ꍇ�͊ۂߍ���
            else if (color.a + Time.deltaTime > 1.5f)
            {
                color.a = 2.0f;
            }
            //�A���t�@�l�����Z����
            else
            {
                color.a += Time.deltaTime;
            }
            image.color = color;
        }
    }


}
