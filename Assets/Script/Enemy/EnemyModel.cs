using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class EnemyModel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _walkSpeed;
    [SerializeField] Enemy _enemy;
    Subject<Unit> _isOutmovement = new Subject<Unit>();


    public void SeekPlayer(float playerPos) 
    {
        //îΩì]èàóù
        Vector3 scale = gameObject.transform.localScale;
        if (_rb.velocity.x < 0 && scale.x > 0 || _rb.velocity.x > 0 && scale.x < 0)
        {
            scale.x *= -1;
        }
        transform.localScale = scale;

        //SeekTarget(playerPos);
        

        //èâä˙ílÇ…ñﬂÇÈ

        //SeekTarget(_enemy.getFirstPosition().x);
        

        


    }

    public IEnumerator SeePlayer(float target)
    {
        float diff_x;
        while (transform.position.x > _enemy.getEnableMovement())
        {
            diff_x = target - transform.position.x;
            _walkSpeed = diff_x < 0 ? _walkSpeed * -1 : _walkSpeed;
            transform.Translate(0.01f * _walkSpeed, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ReturneFirstPosition(float target)
    {
        float diff_x = target - transform.position.x;
        while (diff_x != 0)
        {
            diff_x = target - transform.position.x;
            _walkSpeed = diff_x < 0 ? _walkSpeed * -1 : _walkSpeed;
            transform.Translate(0.01f * _walkSpeed, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }




}
