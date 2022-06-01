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
        //2���_���[�W���󂯂��Ƃ�1�̗̑͂����邩��1�����񂾂�2������
        //_boss1window.OnDeath.Subscribe(_ => { _boss2window.setHp(0); });

    }

    //�㔼��ABoss2���o��
    public void Appear()
    {
        //_boss2.SetActive(true);
        _boss1window.setHp(reHP);
        Debug.Log("Appear");
    }

}
