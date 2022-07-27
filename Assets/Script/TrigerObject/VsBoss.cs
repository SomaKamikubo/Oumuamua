using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class VsBoss : MonoBehaviour
{
    Subject<Unit> vsBossTrig = new Subject<Unit>();

    public IObservable<Unit> VsBossTrigger{get { return vsBossTrig;  }}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("�ڐG����");
        if (other.gameObject.tag == "Player")
            vsBossTrig.OnNext(Unit.Default);
    }

}
