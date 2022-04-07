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


    //Enter�̕����g���Ǝ~�܂��Ă���Ԃ͍U�����󂯂Ȃ����߁AStay���g��
    void OnTriggerStay2D(Collider2D collision)
    {
        //��̍U���ł���������_���[�W�͈��݂̂̂���
        if (!_isGiveDamage)
        {
            
            collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
            
            _isGiveDamage = true;
        }
        
    }

}
