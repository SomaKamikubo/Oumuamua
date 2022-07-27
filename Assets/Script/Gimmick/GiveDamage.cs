using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GiveDamage : MonoBehaviour
{

    //Enterの方を使うと止まっている間は攻撃を受けないため、Stayを使う
    void OnTriggerStay2D(Collider2D collision)
    {
        //一つの攻撃であたえられるダメージは一回のみのため

        if (collision.gameObject.tag == "Player" )
        {
            collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
            
        }
    }



}
