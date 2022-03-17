using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]


public class EnemyStatus : MonoBehaviour
{
    bool isWalking = false;
    bool isAttacking = false;
    bool isDeath = false;
    [SerializeField] Animator animator;
    [SerializeField] EnemyModel EM;
    int HP;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMove(float value)
    {
        Debug.Log(value);
        if (value == 0)
            isWalking = false;
        else
        {
            isWalking = true;
            EM.Move(value);
        }
        anim();
    }

    public void PLayDamage(int value)
    {
        HP = EM.   
    }

    public void PlayAttack(bool keyDown)
    {
        isAttacking = keyDown;
        anim();
    }

    void anim()
    {
        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsAttacking", isAttacking);
        animator.SetBool("IsFalling", isDeath);
    }
}
