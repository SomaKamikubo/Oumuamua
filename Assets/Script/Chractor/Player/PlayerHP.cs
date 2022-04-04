using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : CharactorHP
{
    [SerializeField] PlayerStatus _playerStatus;
    protected override void Start()
    {
        _charactorStatus = _playerStatus;
        base.Start();
    }
}
