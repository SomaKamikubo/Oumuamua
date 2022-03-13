using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    //インターフェース
    void Move(IPlayerModel p)
    {
        p.Walk();
    }

    //実装なし
    void MoveGirl(string PlayerGirl)
    {
        //PlayerGirl.Walk();
    }
    void MoveBoy(string PlayerBoy)
    {
        //PlayerBoy.Walk();
    }

}
