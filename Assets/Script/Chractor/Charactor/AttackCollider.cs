using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D _attackCollider;
    bool _isGiveDamage = false;
    
    public void ColliderOn()
    {
        _attackCollider.enabled = true;
    }

    public void ColliderOff()
    {
        _attackCollider.enabled = false;
        _isGiveDamage = false;
    }

    ////Enterの方を使うと止まっている間は攻撃を受けないため、Stayを使う
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //一つの攻撃であたえられるダメージは一回のみのため
    //    if (!_isGiveDamage)
    //    {
    //        Debug.Log(collision.gameObject);

    //        collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);

    //        _isGiveDamage = true;
    //    }

    //}


    //攻撃がうまくいかないため緊急の代替案
    //以前までの処理だと被っているコライダーの取得が一つしかできず相手のコライダーがなかなか取れなかった
    List<GameObject> colList = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        //ほかのスクリプトでPlayerタグを参照してしまっているので
        //スケルトンをPlayerタグにしてごり押す
        if (other.gameObject.CompareTag("Player") && !colList.Contains(other.gameObject))
            colList.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && colList.Contains(other.gameObject))
            colList.Remove(other.gameObject);
    }
    void Update()
    {
        foreach (GameObject go in colList)
        {
           go.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
        }

    }
}
