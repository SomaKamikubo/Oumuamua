using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;


public class EnemySearch : MonoBehaviour
{

    Subject<bool> _enemyMove = new Subject<bool>();

    public IObservable<bool> EnemyMove { get { return _enemyMove; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            _enemyMove.OnNext(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
                _enemyMove.OnNext(false);
    }
}
