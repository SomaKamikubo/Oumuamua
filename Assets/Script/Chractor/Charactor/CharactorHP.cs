using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/*
 * Model
 * �L�����N�^�[��HP���Ǘ�����N���X
 * HP���X�e�[�^�X����Q�Ƃ��񕜂�_���[�W���󂯂��ۂ̏��������s
 */
public abstract class CharactorHP : MonoBehaviour,IApplyDamage
{
    [SerializeField] SpriteRenderer sp;
    protected CharactorStatus _charactorStatus;

    //�_���[�W���󂯂��Ƃ��Ǝ��񂾂Ƃ��̃C�x���g
    Subject<string> _isDeath = new Subject<string>();
    Subject<string> _isHurt = new Subject<string>();
    Subject<string> _isHeal = new Subject<string>();
    public IObservable<string> OnDeath { get { return _isDeath; } }
    public IObservable<string> OnHurt { get { return _isHurt; } }
    public IObservable<string> OnHeal { get { return _isHeal; } }

    protected bool _damaging = false;
    int _nowHp;
    int _maxHp;

    protected virtual void Start()
    {
        //�Q�[���J�n����HP���Q�Ƃ���
        _maxHp = _charactorStatus.getMaxHp();
        _nowHp = _maxHp;

    }


    bool isDeath()
    {
        return _nowHp <= 0;
    }

    public void Damage(int enemy_atk)
    {
        //Debug.Log("�U�����ꂽ");
        //�_���[�W���󂯂Ă���Ƃ��͍U�����󂯂Ȃ�
        //���񂾌�ɍU�����󂯂Ȃ��悤�ɂ���
        if (!_damaging && !isDeath())
        {
            _nowHp -= enemy_atk;
            _isHurt.OnNext("HurtTrigger");

            //�_�ł�����
            StartCoroutine("Blinking");
            StartCoroutine("CountSecoond", 2.0f);
            if (isDeath())
                Death();
        }
        
    }

    public virtual void Death()
    {
        _isDeath.OnNext("DeathTrigger");//Trigger�𒼐ڎw�肷��̂͂������Ȃ��̂�
    }

    public void Heal(int heal)
    {   
        _nowHp += heal;
        if (_nowHp > _maxHp)
            _nowHp = _maxHp;
        _isHeal.OnNext("Test");
    }



    public int getHp() { return _nowHp; }
    public void setHp(int hp) {_nowHp = hp; }

    IEnumerator Blinking()
    {
        _damaging = true;
        while (_damaging)
        {
            yield return new WaitForSeconds(0.1f);
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            sp.color = new Color(1f, 1f, 1f, level);
            //Debug.Log("�_�Œ�");
        }
        sp.color = new Color(1f, 1f, 1f, 1);
    }

    IEnumerator CountSecoond(float count)
    {
        yield return new WaitForSeconds(count);
        _damaging = false;
    }
}
