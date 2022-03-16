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

    public void InputRight()
    {
        OnInputHrizon?.Invoke(1);
    }

    public void InputLeft()
    {
        OnInputHrizon?.Invoke(-1);
    }

    public void InputIdle()
    {
        OnInputHrizon?.Invoke(0);
    }

    public void InputX()
    {
        OnInputX?.Invoke(true);
    }

    public void OutX()
    {
        OnInputX?.Invoke(false);
    }


}
