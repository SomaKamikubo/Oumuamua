using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class EnemyModel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int walkSpeed;
    [SerializeField] private int _maxHP;
    private int _currentHP;

    public int CurrentHp { get => _currentHp.Value; set => _currentHp.Value = value; }
    public IObservable<int> CurrentChanged => _currentHp;
    private readonly ReactiveProperty<int> _currentHp = new();

    public void Start()
    {
        _currentHP = _maxHP;
    }

    public void Move(float horizontal) 
    {
        rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);

        Vector3 scale = gameObject.transform.localScale;
        if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
        {
            scale.x *= -1;
        }
        gameObject.transform.localScale = scale;
    }
    public void Attack() { }
    public int HP(int damage)
    {
        int _next = _currentHP;
        _next -= UnityEngine.Random.Range(10, 30);
        if (_next < 0)
        {
            _next = 0;
        }
        return currentHP;
    }
}
