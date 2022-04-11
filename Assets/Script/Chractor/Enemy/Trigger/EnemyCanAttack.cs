using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyCanAttack : MonoBehaviour
{
    bool _canAttack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _canAttack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _canAttack = false;
    }

    public bool getCanAttack()
    {
        return _canAttack;
    }
}
