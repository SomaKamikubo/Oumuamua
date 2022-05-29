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
 
            hurtt();
        }
        
    }
    private void hurtt()
    {
        //2‚ªƒ_ƒ[ƒW‚ðŽó‚¯‚½‚Æ‚«1‚Ì‘Ì—Í‚ªŒ¸‚é‚©‚ç1‚ªŽ€‚ñ‚¾‚ç2‚àŽ€‚Ê
        _boss1window.OnDeath.Subscribe(_ =>{ _boss2window._isDeath.OnNext("DeathTrigger"); Debug.Log("death"); }) ;


    }
}
