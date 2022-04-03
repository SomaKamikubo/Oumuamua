using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBGM : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];
    }
    public void A(int index)
    {
        Debug.Log("BGM" + index);
        source.Stop();

        //ループ切り替え(clear,deathは非ループ)
        if (index <= 2)
            source.loop = true;
        else
            source.loop = false;

        source.PlayOneShot(clips[index]);
    }
}
