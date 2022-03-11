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
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (player_status.IsDashing)
            {
                player_status.IsDashAttacking = true;
                GetComponent<Animator>().SetTrigger("DashAttackTrigger");;
                return;
            }
            player_status.IsAttacking = true;
            
            return;
        }
        player_status.IsAttacking = false;

    }

}
