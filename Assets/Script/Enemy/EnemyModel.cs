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
    [SerializeField] GameObject _attackCollider;
    //[SerializeField] Enemy _enemy;


    ReactiveProperty<bool> _isWalking = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isActing = new ReactiveProperty<bool>(true);

    public IReadOnlyReactiveProperty<bool> OnChangeIsWalking { get { return _isWalking; } }

    Subject<string> _isAttacking = new Subject<string>();
    public IObservable<string> OnAttack { get { return _isAttacking; } }

    public void Reverse()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;   
    }

    //��łȂ񂩍l����
    //�߂�ǂ��̂łƂ肠�������艟��
    public void Death()
    {
        _isActing.Value = false;
    }

    public IEnumerator Walk()
    {
        
        int vec = 0;

        while (_isActing.Value)
        {
            _isWalking.Value = true;
            //�����𖈉�v�Z����̂���
            //���������U������̃N���X������̂����炻������A�A�A
            for (int i = 0; i < 10; i++) {
                yield return new WaitForSeconds(0.2f);
                vec = transform.localScale.x > 0 ? vec = 1 : vec = -1;
                _rb.velocity = new Vector2(vec * _walkSpeed, _rb.velocity.y);
                
            }
            // Debug.Log("attack");
            _isWalking.Value = false;
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _isAttacking.OnNext("AttackTrigger");
            //�n�[�h�R�[�f�B���O
            yield return new WaitForSeconds(0.5f);
            _attackCollider.GetComponent<CapsuleCollider2D>().enabled = true;
            yield return new WaitForSeconds(1.0f);
            _attackCollider.GetComponent<CapsuleCollider2D>().enabled = false;

        }
    }

    void OnBecameVisible()
    {
        StartCoroutine("Walk");
        //Debug.Log("�J�����ɉf����");
    }

    void OnBecameInvisible()
    {
        //_enemy.Initialized();
    }



    //public IEnumerator SeeKPlayer(float targetX)
    //{
    //    float diff_x;
    //    int vec;
    //    //�ڕW�l���E���ɂ���ꍇ
    //    while (_enemy.getEnableMovement() < transform.position.x)
    //    {
    //        diff_x = targetX - transform.position.x;   //�v���C���[�Ƃ̋��������߂�
    //        vec = diff_x < 0 ? -1 :1;    //�x�N�g�������߂�
    //        transform.localScale *= transform.localScale.x * vec;
    //        transform.Translate(0.01f * _walkSpeed * vec, 0, 0);
    //        yield return new WaitForSeconds(1f);
    //    }
    //}

    ////�����l�ɖ߂�
    //IEnumerator ReturneFirstPosition(float target)
    //{
    //    float diff_x = target - transform.position.x;
    //    while (diff_x != 0)
    //    {
    //        diff_x = target - transform.position.x;
    //        _walkSpeed = diff_x < 0 ? _walkSpeed * -1 : _walkSpeed;
    //        transform.Translate(0.01f * _walkSpeed, 0, 0);
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}




}
