using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] int _time;
    Rigidbody2D _rb;
    [SerializeField] float _speed;

    Vector3 rote;

    void Start()
    {
        move();
        Destroy(gameObject, _time);
    }

     void move()
    {
        float direction;
        rote = transform.localEulerAngles;
        _rb = GetComponent<Rigidbody2D>();

        direction = Mathf.Cos(rote.y * Mathf.Deg2Rad);

        _rb.AddForce(new Vector2(_speed * direction, 0));
    }
}
