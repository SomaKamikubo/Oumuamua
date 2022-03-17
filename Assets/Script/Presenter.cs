using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
[RequireComponent(typeof(Animator))]

public class Presenter : MonoBehaviour
{
    [SerializeField] InputView input_view;
    [SerializeField] PlayerMove player_move;
    [SerializeField] PlayerStatus _status;

    private void Start()
    {
        //input_view.OnSKeyPressedListener += KeyDownS => { animator.SetBool("IsCrouching", KeyDownS); };

        //view���烆�[�U�[�̓��͂��������Ƃ��󂯎��
        input_view.OnSKeyPressedListener += KeyDownS => { player_move.Crounch(KeyDownS); };
        input_view.OnShiftKeyPressedListener += KeyDownShift => {player_move.receiveShift(KeyDownShift); };
        input_view.OnSpaceKeyPressedListener += () => player_move.Jump();

        //model����view��
        //�R�[���o�b�N�֐��g������
        player_move.OnChangeIsJumping.Subscribe(value => input_view.SetAnimetor("IsJumping", value));
        player_move.OnChangeIsFalling.Subscribe(value => { input_view.SetAnimetor("IsFalling", value); Debug.Log("isFalling��"+value+"�ɂȂ����B"); });
        player_move.OnChangeIsWalking.Subscribe(value => input_view.SetAnimetor("IsWalking", value));
        player_move.OnChangeIsDashing.Subscribe(value => input_view.SetAnimetor("IsDashing", value));
        player_move.OnChangeIsCrouching.Subscribe(value => input_view.SetAnimetor("IsCrouching", value));

        //view����model��
        input_view.OnMove.Subscribe(amount => player_move.Move(amount));
    }

}
