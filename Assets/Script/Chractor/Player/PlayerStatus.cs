using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの状態をまとめる
//プレイヤーの状態の情報が欲しい場合はここを参照
public class PlayerStatus :CharactorStatus
{
    [SerializeField] int _dashSpeed;
    [SerializeField] int _jumpPower;


    public int getDashSpeed() { return _dashSpeed; }
    public int getJumpPower() { return _jumpPower; }

}
