using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̍U������������N���X
public class PlayerAttack : MonoBehaviour
{
    bool isAttacking;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isAttacking = true;
            return;
        }
        isAttacking = false;
    }

    public bool IsAttacking { get { return isAttacking; } }

}
