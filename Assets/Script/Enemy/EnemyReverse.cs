using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class EnemyReverse : MonoBehaviour
{
    [HideInInspector] public bool isOn = false;
    Subject<Unit> _collideStage = new Subject<Unit>();
    public IObservable<Unit> OnCollideStage { get { return _collideStage; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("‚Ô‚Â‚©‚Á‚½");
    
       
        if (collision.tag =="Stage")
        {
            _collideStage.OnNext(Unit.Default);
        }
    }
}
