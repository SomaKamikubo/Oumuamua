using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class BossManager : MonoBehaviour
{
    [SerializeField] EnemyWindow _boss1window;
    [SerializeField] EnemyWindow _boss2window;
    [SerializeField] GameObject _boss2;

    bool first = true;
    int reHP;
    private void Start()
    {
        reHP = _boss1window.getMaxHp();
        
    }
    private void Update()
    {
        if(_boss1window.getHp() <= (_boss1window.getMaxHp()/2) && first)
        {
            Debug.Log(_boss1window.getHp());
            first = false;
            _boss2.SetActive(true);
            _boss1window.setHp(reHP);
            _boss2window.setHp(reHP);
            hurtt();
        }
        
    }
    private void hurtt()
    {
        _boss2window.OnHurt.Subscribe(_ => _boss1window.setHp(_boss1window.getHp() - 1));
        _boss1window.OnHurt.Subscribe(_ => _boss2window.setHp(_boss2window.getHp() - 1));
        //‚¤‚í‚ ‚ ‚ ‚ 
        //â‘Î‘‚«Š·‚¦‚Ü‚µ‚å‚¤
       // _boss1window.OnDeath.Subscribe(_ => _boss2window._isDeath.OnNext("DeathTrigger"));
        _boss2window.OnDeath.Subscribe(_ => _boss1window._isDeath.OnNext("DeathTrigger"));

    }
}
