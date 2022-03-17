using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̏�Ԃ��܂Ƃ߂�
//�v���C���[�̏�񂪗~�����ꍇ�͂������Q��
public class PlayerStatus : MonoBehaviour
{

    [SerializeField] PlayerAttack player_attack;
    [SerializeField] PlayerMove player_move;

    //��Collider
    [SerializeField] GameObject land;
    [SerializeField] GameObject wall_slide;
    //PlayerAttack player_attack = new PlayerAttack();


    //public bool IsAttacking { get { return player_attack.IsAttacking; } }
    public bool IsMoving { get {return player_move.IsMoving;}}
    public bool IsWalking { get { return player_move.IsWalking; } }
    public bool IsDashing { get { return player_move.IsDashing; } }
    public bool IsCrouching { get { return player_move.IsCrouching; } }
    public bool IsJumping { get { return player_move.IsJumping; } }
    public bool IsFalling { get { return player_move.IsFalling; } }
    public bool IsWallSliding { get { return wall_slide.GetComponent<WallSlide>().IsWallSliding; } }
}
