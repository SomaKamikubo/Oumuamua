using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerWindow _playerWindow;
    // Start is called before the first frame update
    void Start()
    {
        _playerWindow.GenerateHeart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
