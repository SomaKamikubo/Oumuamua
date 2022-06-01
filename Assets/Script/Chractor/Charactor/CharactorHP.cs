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


    ReactiveProperty<int> _nowHp = new ReactiveProperty<int>();
    Subject<Unit> _isDeath = new Subject<Unit>();
    public IReadOnlyReactiveProperty<int> OnChangeHP { get { return _nowHp; } }
    public IObservable<Unit> OnDeath { get { return _isDeath; } }

    protected bool _damaging = false;
    int _maxHp;

    protected virtual void Start()
    {
        //�Q�[���J�n����HP���Q�Ƃ���
        _maxHp = _charactorStatus.getMaxHp();
        _nowHp.Value = _maxHp;

    }


    public bool isDeath()
    {
        return _nowHp.Value <= 0;
    }
    public virtual void Death()
    {
        //_isDeath.OnNext(Unit.Default);
    }


    public virtual void Damage(int enemy_atk)
    {
        //�_���[�W���󂯂Ă���Ƃ��͍U�����󂯂Ȃ�
        //���񂾌�ɍU�����󂯂Ȃ��悤�ɂ���
        if (!_damaging && !isDeath())
        {
            _nowHp.Value -= enemy_atk;

            if (isDeath())
            {
                Death();
                return;
            }
            //�_�ł�����
            StartCoroutine("Blinking");
            StartCoroutine("CountSecoond", 2.0f);
        }
        
    }




    public void Heal(int heal)
    {   
        _nowHp.Value += heal;
        if (_nowHp.Value > _maxHp)
            _nowHp.Value = _maxHp;
    }



    public int getHp() { return _nowHp.Value; }
    public void setHp(int hp) {_nowHp.Value = hp; }

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
