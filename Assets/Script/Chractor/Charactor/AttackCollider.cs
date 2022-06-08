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

        transform.Translate(0.1f, 0, 0); //stay�͓����Ƃ���ɂ���Ɣ������Ȃ����炸�炵�đ΍�

    }

    public void ColliderOff()
    {
        _isGiveDamage = false;
        _attackCollider.enabled = false;
        transform.position = _position;
    }

    //Enter�̕����g���Ǝ~�܂��Ă���Ԃ͍U�����󂯂Ȃ����߁AStay���g��
    void OnTriggerStay2D(Collider2D collision)
    {
        //��̍U���ł���������_���[�W�͈��݂̂̂���

       if(!_isGiveDamage && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") )
       {
             collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
            _isGiveDamage = true;
       }
    }



}
