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

        //viewからユーザーの入力が来たことを受け取る
        input_view.OnSKeyPressedListener += KeyDownS => { player_move.Crounch(KeyDownS); };
        input_view.OnShiftKeyPressedListener += KeyDownShift => {player_move.receiveShift(KeyDownShift); };
        input_view.OnSpaceKeyPressedListener += () => player_move.Jump();

        //modelからviewへ
        //コールバック関数使いたい
        player_move.OnChangeIsJumping.Subscribe(value => input_view.SetAnimetor("IsJumping", value));
        player_move.OnChangeIsFalling.Subscribe(value => { input_view.SetAnimetor("IsFalling", value); Debug.Log("isFallingが"+value+"になった。"); });
        player_move.OnChangeIsWalking.Subscribe(value => input_view.SetAnimetor("IsWalking", value));
        player_move.OnChangeIsDashing.Subscribe(value => input_view.SetAnimetor("IsDashing", value));
        player_move.OnChangeIsCrouching.Subscribe(value => input_view.SetAnimetor("IsCrouching", value));

        //viewからmodelへ
        input_view.OnMove.Subscribe(amount => player_move.Move(amount));
    }

}
