using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyView : MonoBehaviour
{
    public event Action<float> OnInputHrizon;
    public event Action<bool> OnInputX;
    float value;




    private void Update()
    {
        value = Input.GetAxis("Horizontal");
        OnInputHrizon?.Invoke(value);

        if (Input.GetKey(KeyCode.X))
        {
            OnInputX?.Invoke(true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            OnInputX?.Invoke(false);
        }
    }
}
