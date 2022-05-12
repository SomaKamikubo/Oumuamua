using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] int _time;
    Rigidbody2D _rb;
    [SerializeField] float _speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(transform.right * _speed);
        Destroy(gameObject, _time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
