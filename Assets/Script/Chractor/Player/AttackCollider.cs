using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��������");
        collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
    }

}
