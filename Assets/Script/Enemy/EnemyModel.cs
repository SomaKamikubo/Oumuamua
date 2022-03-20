using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class EnemyModel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _walkSpeed;
    [SerializeField] Enemy _enemy;
    

    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);

    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    public void Reverse()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;   
    }

    void OnBecameVisible()
    {
        StartCoroutine("Walk");
        Debug.Log("カメラに映った");
    }

    //private void OnWillRenderObject()
    //{
    //    if (Camera.current.name == "Main Camera")
    //    {
    //        StartCoroutine("Walk");
    //        Debug.Log("カメラに映った");
    //    }
    //}
    void OnBecameInvisible()
    {
        //_enemy.Initialized();
    }


    public IEnumerator Walk()
    {
        _isWalking.Value = true;
        int vec = 0;
        //Debug.Log("歩いています");
        //目標値より右側にいる場合
        while (_isWalking.Value)
        {
            if (transform.localScale.x > 0)
            {
                vec = 1;
            }
            else if(transform.localScale.x < 0)
            {
                vec = -1;
            }
            //transform.Translate(0.01f * _walkSpeed * vec, 0, 0);
            _rb.velocity = new Vector2(vec, _rb.velocity.y);
            yield return new WaitForSeconds(0.1f);
            //Debug.Log(_isWalking.Value);
        }
    }

    //後でなんか考えよ
    //めんどいのでとりあえずごり押し
    public void Death()
    {
        _isWalking.Value = false;
        Debug.Log("しんだ");
    }

    public IEnumerator SeeKPlayer(float targetX)
    {
        float diff_x;
        int vec;
        //目標値より右側にいる場合
        while (_enemy.getEnableMovement() < transform.position.x)
        {
            diff_x = targetX - transform.position.x;   //プレイヤーとの距離を求める
            vec = diff_x < 0 ? -1 :1;    //ベクトルを決める
            transform.localScale *= transform.localScale.x * vec;
            transform.Translate(0.01f * _walkSpeed * vec, 0, 0);
            yield return new WaitForSeconds(1f);
        }
    }

    //初期値に戻る
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
