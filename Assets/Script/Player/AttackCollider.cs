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
    void ColliderReset()
    {

        _attackCollider.GetComponent<CapsuleCollider2D>().enabled = false;

    }

    //void OnTriggerEnter2D(Collision2D collision)
    //{
    //    Debug.Log("aa");
    //    collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
    //    Invoke("ColliderReset", 0.3f);
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
       // Debug.Log("aa");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aa");
        collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
        Invoke("ColliderReset", 0.3f);
    }
}
