using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorStatus : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _atk;
    [SerializeField] int _walkSpeed;


    public int getMaxHp() { return _maxHp; }
    public int getATK() { return _atk; }
    public int getWalkSpeed() { return _walkSpeed; }
}
