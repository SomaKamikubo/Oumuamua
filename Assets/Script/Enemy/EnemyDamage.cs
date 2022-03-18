using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class EnemyDamage : MonoBehaviour
{
    public int CurrentHp { get => _currentHp.Value; set => _currentHp.Value = value; }
    public IObservable<int> CurrentChanged => _currentHp;
    private readonly ReactiveProperty<int> _currentHp;
    public void Damage(int atk)
    {
        int _next = CurrentHp;
        _next -= atk;
        if (_next < 0)
        {
            _next = 0;
        }
        _currentHp.Value = _next;
    }
}
