using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    //�C���^�[�t�F�[�X
    void Move(IPlayerModel p)
    {
        p.Walk();
    }

    //�����Ȃ�
    void MoveGirl(string PlayerGirl)
    {
        //PlayerGirl.Walk();
    }
    void MoveBoy(string PlayerBoy)
    {
        //PlayerBoy.Walk();
    }

}
