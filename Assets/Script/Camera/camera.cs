using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField]  GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       Vector3 playerPos = player.gameObject.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y+1, transform.position.z);

        

    }
}
