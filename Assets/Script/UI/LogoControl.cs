using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogoControl : MonoBehaviour
{

    public float soundTime = 1.0f;    //�����Đ��̊J�n�^�C�~���O(�b)
    public float fadeOutTime = 6.0f;  //�t�F�[�h�A�E�g�̊J�n�^�C�~���O(�b)
    private float nowTime = 0.0f;     //�^�C�~���O�J�E���g�p

    public GameObject panel;          //�t�F�[�h�A�E�g�p�p�l��UI�I�u�W�F�N�g
    private Image image;              //panel�̃R���|�[�l���g
    private Color color;              //panel�̃J���[�ݒ�
    private AudioSource audioSource;  //�����Đ��p�̃I�[�f�B�I�\�[�X
    private bool soundFlg = false;    //�����Đ��p�t���O

    void Start()
    {
        //�����Đ��p�̃I�[�f�B�I�\�[�X�擾
        audioSource = GetComponent<AudioSource>();

        //�t�F�[�h�A�E�g�p�̃p�����[�^�擾
        image = panel.GetComponent<Image>();
        color = image.color;
    }

    void Update()
    {
        //deltaTime�����Z���Čo�ߎ��Ԃ��v�Z����
        nowTime += Time.deltaTime;

        //�w��̕b�����o�߂����ہA1�x�����������Đ�����
        if (soundTime < nowTime && soundFlg == false)
        {
            audioSource.Play();
            soundFlg = true;
        }

        //�w��̕b�����o�߂����ہA�t�F�[�h�A�E�g���ăV�[����J�ڂ���
        if (fadeOutTime < nowTime)
        {
            //�t�F�[�h�A�E�g���I�������V�[���J�ڂ�����
            if (color.a == 2.0f)
            {
                SceneManager.LoadScene("Title");
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