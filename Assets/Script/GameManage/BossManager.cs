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

    int reHP;
    private void Start()
    {
        reHP = _boss1window.getMaxHp();
    }

    //å„îºêÌÅABoss2Çèoåª
    public void Appear()
    {
        _boss2.SetActive(true);
        _boss1window.setHp(reHP);
        //Debug.Log("Appear");
    }

}
