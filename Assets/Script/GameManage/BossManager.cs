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
        //2がダメージを受けたとき1の体力が減るから1が死んだら2も死ぬ
        //_boss1window.OnDeath.Subscribe(_ => { _boss2window.setHp(0); });

    }

    //後半戦、Boss2を出現
    public void Appear()
    {
        //_boss2.SetActive(true);
        _boss1window.setHp(reHP);
        Debug.Log("Appear");
    }

}
