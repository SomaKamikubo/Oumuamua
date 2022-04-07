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

    ////Enter�̕����g���Ǝ~�܂��Ă���Ԃ͍U�����󂯂Ȃ����߁AStay���g��
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //��̍U���ł���������_���[�W�͈��݂̂̂���
    //    if (!_isGiveDamage)
    //    {
    //        Debug.Log(collision.gameObject);

    //        collision.gameObject.GetComponent<IApplyDamage>()?.Damage(1);

    //        _isGiveDamage = true;
    //    }

    //}


    //�U�������܂������Ȃ����ߋً}�̑�ֈ�
    //�ȑO�܂ł̏������Ɣ���Ă���R���C�_�[�̎擾��������ł�������̃R���C�_�[���Ȃ��Ȃ����Ȃ�����
    List<GameObject> colList = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        //�ق��̃X�N���v�g��Player�^�O���Q�Ƃ��Ă��܂��Ă���̂�
        //�X�P���g����Player�^�O�ɂ��Ă��艟��
        if (other.gameObject.CompareTag("Player") && !colList.Contains(other.gameObject))
            colList.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && colList.Contains(other.gameObject))
            colList.Remove(other.gameObject);
    }
    void Update()
    {
        foreach (GameObject go in colList)
        {
           go.gameObject.GetComponent<IApplyDamage>()?.Damage(1);
        }

    }
}
