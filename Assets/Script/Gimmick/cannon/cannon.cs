using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    [SerializeField] float _startTime;
    [SerializeField] float _intervalTime;
    [SerializeField] GameObject ball_pre;
    [SerializeField] GameObject ball_initpos;

 

    void Start()
    {
        InvokeRepeating(nameof(shotball), _startTime, _intervalTime);
    }

    void shotball()
    {
        Instantiate(ball_pre, ball_initpos.transform.position, Quaternion.Euler(transform.eulerAngles));
    }
}
