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
        //Walkの値を変化させる変数をリストに加える
        _walkChangeList.Add(_canAttack);

        _attackChangeList.Add(_canAttack);

        //アニメーションが終わったことをうけとり、フラグをtureにする
        _animatorView.OnFinish.Subscribe(finishAnimation => { 
            _canAttack.Value = true;
        });

        
    }
    
    public virtual void Control(string key)
    {
        switch (key)
        {
            case "Attack"://攻撃
                if (isAllTrue(_attackChangeList))
                {
                    //動けるなら動き、フラグをfalseにする
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
        //引数のリストにfalseが入っていたらtrueを返す
        foreach(ReactiveProperty<bool> item in myList)
        {
            //Debug.Log("falseのもの:" + item);
            if (!item.Value)
            {
                
                return false;
            }
        }
        return true;
        

    } 
}
