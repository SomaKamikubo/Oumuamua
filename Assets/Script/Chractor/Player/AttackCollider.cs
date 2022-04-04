using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("‚ ‚½‚Á‚½");
        collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
        
       
    }

}
