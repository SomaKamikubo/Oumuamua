using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Boss2Input :CharactorInput
{

    [SerializeField] GameObject Player;

    Vector3 initPosition, playPos, enePos;
    void Start()
    {
        playPos = Player.transform.position;

        StartCoroutine("Action");
    }
    IEnumerator Action()
    {
        yield return new WaitForSeconds(5f);
        playPos = Player.transform.position;
        _DownKey.OnNext("Z");

    }

}
