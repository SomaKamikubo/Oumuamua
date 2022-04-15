using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class BossManager : MonoBehaviour
{
    [SerializeField] EnemyWindow _boss1win;
    [SerializeField] EnemyWindow _boss2win;
    [SerializeField] GameObject _boss2;

    bool first = true;
    int reHP;
    private void Start()
    {
        reHP = _boss1win.getMaxHp();
        
    }
    private void Update()
    {
        if(_boss1win.getHp() <= (_boss1win.getMaxHp()/2) && first)
        {
            Debug.Log(_boss1win.getHp());
            first = false;
            _boss2.SetActive(true);
            _boss1win.setHp(reHP);
            _boss2win.setHp(reHP);
            hurtt();
        }
        
    }
    private void hurtt()
    {
        _boss2win.OnHurt.Subscribe(_ => _boss1win.setHp(_boss1win.getHp() - 1));
        _boss1win.OnHurt.Subscribe(_ => _boss2win.setHp(_boss2win.getHp() - 1));
    }
}
