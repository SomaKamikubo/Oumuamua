using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Presenter : MonoBehaviour
{
    [SerializeField] InputView input_view;
    //[SerializeField] PlayerStatus PS;
    [SerializeField] Animator animator;
    //[SerializeField] PlayerMove player_move;
    private void Start()
    {
       input_view.OnInputS += KeyDownS => { animator.SetBool("IsCrouching", KeyDownS);  };
    }
    
}
