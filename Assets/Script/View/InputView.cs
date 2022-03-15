using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputView : MonoBehaviour
{
    public event Action<bool> OnInputS;



    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            OnInputS?.Invoke(true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            OnInputS?.Invoke(false);
        }
    }
}
