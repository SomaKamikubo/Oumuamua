using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    [SerializeField] float _startTime;
    [SerializeField] float _intervalTime;
    [SerializeField] Vector3 _appearance;
    [SerializeField] GameObject ball_pre;

    void Start()
    {
        //���݈ʒu�ɍ��킹�č��W��ύX
        _appearance = transform.position + _appearance;

        InvokeRepeating(nameof(shotball), _startTime, _intervalTime);

    }

    void shotball()
    {
        Instantiate(ball_pre, _appearance, Quaternion.identity);
    }
}
