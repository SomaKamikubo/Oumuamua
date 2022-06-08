using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    [SerializeField] protected CapsuleCollider2D _attackCollider;
    bool _isGiveDamage = false;

    Vector3 _position;

    public void ColliderOn()
    {
        _position = transform.position;
        _attackCollider.enabled = true;

        transform.Translate(0.1f, 0, 0); //stayは同じところにいると反応しないからずらして対策

    }

    public void ColliderOff()
    {
        _isGiveDamage = false;
        _attackCollider.enabled = false;
        transform.position = _position;
    }

    //Enterの方を使うと止まっている間は攻撃を受けないため、Stayを使う
    void OnTriggerStay2D(Collider2D collision)
    {
        //一つの攻撃であたえられるダメージは一回のみのため

       if(!_isGiveDamage && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") )
       {
             collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
            _isGiveDamage = true;
       }
    }



}
