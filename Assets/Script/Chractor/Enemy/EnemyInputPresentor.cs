using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyInputPresentor : MonoBehaviour
{
    [SerializeField] EnemyController _enemyController;
    [SerializeField] EnemyWindow _enemyWindow;

    void Start()
    {

        _enemyController.OnDownHorizontalKey.Subscribe(value => _enemyWindow.Walk(value));
        _enemyController.OnDownKey.Subscribe(key => _enemyWindow.Attack());

    }
}
