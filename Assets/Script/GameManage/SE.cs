using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource source;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        // �A�^�b�`�����I�[�f�B�I�\�[�X�̂���1�Ԗڂ��g�p����
        source = GetComponents<AudioSource>()[0];
    }
    public void playSE(int index)
    {
       
       source.PlayOneShot(clips[index]);
    }
}
