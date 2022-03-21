using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    //[SerializeField] CapsuleCollider _attackCollider;
    [SerializeField]GameObject _attackCollider;

    private void Start()
    {
        //_attackCollider = _attackCollider.GetComponent<CapsuleCollider>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
       
    }
}
