using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    [SerializeField]int _healPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerWindow>().Heal(_healPower);
            Debug.Log(collision.gameObject.GetComponent<PlayerWindow>().getHp());
            Destroy(gameObject);
        }  
    }



}
