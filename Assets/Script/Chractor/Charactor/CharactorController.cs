using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class CharactorController : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;

    protected ReactiveProperty<bool> _canAttack = new ReactiveProperty<bool>(true);
    protected bool _canWalk;
    //public IReadOnlyReactiveProperty<bool> OnChangeCanAttack { get { return _canAttack; } }
    protected List<ReactiveProperty<bool>> _walkChangeList = new List<ReactiveProperty<bool>>();
    protected List<ReactiveProperty<bool>> _attackChangeList = new List<ReactiveProperty<bool>>();



    protected virtual void Start()
    {
        //Walk�̒l��ω�������ϐ������X�g�ɉ�����
        _walkChangeList.Add(_canAttack);

        _attackChangeList.Add(_canAttack);

        //�A�j���[�V�������I��������Ƃ������Ƃ�A�t���O��ture�ɂ���
        _animatorView.OnFinish.Subscribe(finishAnimation => { 
            _canAttack.Value = true;
        });

        
    }
    
    public virtual void Control(string key)
    {
        switch (key)
        {
            case "Attack"://�U��
                if (isAllTrue(_attackChangeList))
                {
                    //������Ȃ瓮���A�t���O��false�ɂ���
                    _charactorWindow.Attack();
                    _canAttack.Value = false;
                    _animatorView.StartCoroutine("PlayAnimation", "Attack");
                }
                break;
        }
    }

    public virtual void ControlWalk(float value)
    {
        _canWalk = isAllTrue(_walkChangeList);
        //Debug.Log("_canWalk:" + _canWalk);
        if (_canWalk)
        {
            _charactorWindow.Walk(value);
        }
        else
        {
            _charactorWindow.Stop();
        }
        
    }
    
    
    protected bool isAllTrue(List<ReactiveProperty<bool>> myList)
    {
        //�����̃��X�g��false�������Ă�����true��Ԃ�
        foreach(ReactiveProperty<bool> item in myList)
        {
            //Debug.Log("false�̂���:" + item);
            if (!item.Value)
            {
                
                return false;
            }
        }
        return true;
        

    } 
}
