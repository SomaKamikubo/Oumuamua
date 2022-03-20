using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

//プレイヤーの攻撃を実装するクラス
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Player _player;
    [SerializeField] PlayerStatus _ps;
    [SerializeField]GameObject _attackCollider;




    //TriggerAnimetion _triAni = new TriggerAnimetion();
    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }

    //AudioSource source;
    //[SerializeField] AudioClip[] clips;

    public void Start()
    {
        //source = GetComponents<AudioSource>()[0];
    }
    public void Attack()
    {
        if(!_ps.IsFalling && !_ps.IsJumping)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            //_triAni.AttackAnimation();
            _isAttacking.OnNext("AttackTrigger");
            _attackCollider.GetComponent<CapsuleCollider2D>().enabled = true;
        }
       

    }
    
    




}
