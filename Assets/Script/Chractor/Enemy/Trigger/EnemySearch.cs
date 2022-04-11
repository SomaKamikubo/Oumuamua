using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;


public class EnemySearch : MonoBehaviour
{
    ReactiveProperty<bool> _enemyMove = new ReactiveProperty<bool>(false);

    public IReadOnlyReactiveProperty<bool> EnemyMove { get { return _enemyMove; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            _enemyMove.Value = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
                _enemyMove.Value = false;
    }
}
