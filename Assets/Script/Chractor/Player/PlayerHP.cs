using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : CharactorHP
{
    [SerializeField] PlayerStatus _playerStatus;

    protected void Awake()
    {
        _charactorStatus = _playerStatus;
    }
}
