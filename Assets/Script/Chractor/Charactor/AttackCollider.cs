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


    //Enterの方を使うと止まっている間は攻撃を受けないため、Stayを使う
    void OnTriggerStay2D(Collider2D collision)
    {
        //一つの攻撃であたえられるダメージは一回のみのため
        if (!_isGiveDamage)
        {
            
            collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
            
            _isGiveDamage = true;
        }
        
    }

}
