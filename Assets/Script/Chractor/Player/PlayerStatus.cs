using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̏�Ԃ��܂Ƃ߂�
//�v���C���[�̏�Ԃ̏�񂪗~�����ꍇ�͂������Q��
public class PlayerStatus :CharactorStatus
{
    [SerializeField] int _dashSpeed;
    [SerializeField] int _jumpPower;


    public int getDashSpeed() { return _dashSpeed; }
    public int getJumpPower() { return _jumpPower; }

}
