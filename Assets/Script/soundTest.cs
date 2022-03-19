using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTest : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource source;
    [SerializeField] AudioClip[] clips;

    private void Awake()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];
    }
    public void A(int index)
    {  
       source.PlayOneShot(clips[index]);
    }
}
