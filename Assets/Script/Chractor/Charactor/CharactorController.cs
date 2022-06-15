using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class CharactorController : MonoBehaviour
{
    protected CharactorWindow _charactorWindow;
    protected AnimatorView _animatorView;
    protected bool _canAct = true;

    protected virtual void Start()
    {
        //�A�j���[�V�������I��������Ƃ������Ƃ�A�t���O��ture�ɂ���
        _animatorView.OnFinish.Subscribe(finishAnimation => { 
            _canAct = true;
        });
    }
    public virtual void Control(string key)
    {
        switch (key)
        {
            case "Attack"://�U��
                if (_canAct)
                {
                    //������Ȃ瓮���A�t���O��false�ɂ���
                    _charactorWindow.Attack();
                    _canAct = false;
                    _animatorView.StartCoroutine("PlayAnimation", "Attack");
                }
                break;
        }
    }
}
