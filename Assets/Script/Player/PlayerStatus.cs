using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�̏�Ԃ��܂Ƃ߂�
//�v���C���[�̏�Ԃ̏�񂪗~�����ꍇ�͂������Q��
public class PlayerStatus : MonoBehaviour
{
    [SerializeField] PlayerMove player_move;

    //��Collider
    [SerializeField] GameObject wall_slide;

    public bool IsMoving { get {return player_move.IsMoving;}}
    public bool IsWalking { get { return player_move.IsWalking; } }
    public bool IsDashing { get { return player_move.IsDashing; } }
    public bool IsCrouching { get { return player_move.IsCrouching; } }
    public bool IsJumping { get { return player_move.IsJumping; } }
    public bool IsFalling { get { return player_move.IsFalling; } }
    public bool IsWallSliding { get { return wall_slide.GetComponent<WallSlide>().IsWallSliding; } }
}
