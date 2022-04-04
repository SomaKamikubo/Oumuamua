using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : CharactorHP
{
    [SerializeField] PlayerStatus _playerStatus;
    private void Start()
    {
        _charactorStatus = _playerStatus;
    }
}
