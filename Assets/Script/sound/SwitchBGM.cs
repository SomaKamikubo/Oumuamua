using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBGM : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        // �A�^�b�`�����I�[�f�B�I�\�[�X�̂���1�Ԗڂ��g�p����
        source = GetComponents<AudioSource>()[0];
    }
    public void PlayBGM(int index)
    {
        source.Stop();

        //���[�v�؂�ւ�(clear,death�͔񃋁[�v)
        if (index <= 2)
            source.loop = true;
        else
            source.loop = false;

        source.clip = clips[index];

        source.Play();
    }
}
