using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]


public class EnemyStatus : MonoBehaviour
{
    bool isWalking = false;
    bool isAttacking = false;
    bool isDeath = false;
    //[SerializeField] Animator animator;
    [SerializeField] EnemyModel EM;




    public void PlayMove(float value)
    {
        Debug.Log(value);
        if (value == 0)
            isWalking = false;
        else
        {
            isWalking = true;
        }
        //EM.Move(value);
        //anim();
    }

    //public void PLayDamage(int value)
    //{
    //    EM.Damage(value);
    //    if (EM.CurrentHp == 0)
    //        isDeath = true;

    //    anim();
    //}

    public void PlayAttack(bool keyDown)
    {
       
        isAttacking = keyDown;
        //anim();
    }

    
}
