using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GiveDamage : MonoBehaviour
{

    //Enter�̕����g���Ǝ~�܂��Ă���Ԃ͍U�����󂯂Ȃ����߁AStay���g��
    void OnTriggerStay2D(Collider2D collision)
    {
        //��̍U���ł���������_���[�W�͈��݂̂̂���

        if (collision.gameObject.tag == "Player" )
        {
            collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
            
        }
    }



}
