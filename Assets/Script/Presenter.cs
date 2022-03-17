using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

[RequireComponent(typeof(Animator))]

public class Presenter : MonoBehaviour
{
    [SerializeField] InputView input_view;
    [SerializeField] PlayerMove player_move;
    [SerializeField] PlayerStatus _status;

    private void Start()
    {

        //viewからイベントを受け取る
        //input_view.OnShiftKeyPressedListener += KeyDownShift => {player_move.receiveShift(KeyDownShift); };

        //modelからviewへ
        //コールバック関数にする
        player_move.OnChangeIsJumping.Subscribe(value => input_view.SetAnimetor("IsJumping", value));
        player_move.OnChangeIsFalling.Subscribe(value => { input_view.SetAnimetor("IsFalling", value);; });
        player_move.OnChangeIsWalking.Subscribe(value => { input_view.SetAnimetor("IsWalking", value);});
        player_move.OnChangeIsDashing.Subscribe(value => input_view.SetAnimetor("IsDashing", value));
        player_move.OnChangeIsCrouching.Subscribe(value => input_view.SetAnimetor("IsCrouching", value));

        //viewからmodelへ
        input_view.OnDownHorizontalKey.Subscribe(amount => player_move.Move(amount));
        input_view.OnDownKey.Subscribe(key => ProcessKey(key));
        input_view.OnDownSKey.Subscribe(isKeyPressS => player_move.Crounch(isKeyPressS));
        input_view.OnDownShiftKey.Subscribe(isKeyPressShift => player_move.receiveShift(isKeyPressShift));


        void ProcessKey(string key)
        {
            switch (key){
                case "k":
                    break;

                case "Space":
                    player_move.Jump();
                    break;
            }
        
        }

        
    }

}
