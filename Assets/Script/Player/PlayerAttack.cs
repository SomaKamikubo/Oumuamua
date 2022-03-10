using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerStatus player_status;
    // Start is called before the first frame update
    void Start()
    {
        player_status = player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.K) && player_status.IsDashing)
            {
                GetComponent<Animator>().SetTrigger("DashAttackTrigger");
            }
            //else
            //{
            //    player_status.IsAttacking = true;
            //}

       
    }

}
