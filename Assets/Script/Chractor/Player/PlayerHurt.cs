using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] GameObject HP;//ハートオブジェクト
    [SerializeField] GameObject[] heart;//ハート配列
    [SerializeField] GameObject hart;//ハートを置くキャンバス
    [SerializeField] PlayerWindow _playerWindow;
    [SerializeField] float _add_pos;
    int _maxHp;
    

    private void Start()
    {
        _maxHp = _playerWindow.getMaxHp();
        generalHeart(_maxHp);
    }

    public void generalHeart(int maxHp)
    {
        Vector3 _pos = HP.transform.position; 
        heart = new GameObject[maxHp];

        heart[0] = HP;
        for (int i = 1; i < maxHp; i++)
        {
            _pos.x += _add_pos;
            heart[i] = Instantiate(HP, _pos, Quaternion.identity, hart.transform);
        }
    }


    //HPを反映する
    public void DamageViewHeart(int hp)
    {
        //ダメージ受けたとき
        if (heart[hp].gameObject.activeSelf)
        {
            heart[hp].gameObject.SetActive(false);
        }

    }

    public void HealViewHeart(int hp)
    {
        ////ヒールの時の処理
        if (!heart[hp - 1].gameObject.activeSelf)
        {
            heart[hp - 1].gameObject.SetActive(true);
        }
    }
}
