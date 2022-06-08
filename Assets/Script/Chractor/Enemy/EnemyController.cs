using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class EnemyController : CharactorInput
{
    [SerializeField] float attackArea;
    [SerializeField] float posArea; 
    [SerializeField] GameObject Player;
    [SerializeField] EnemySearch _enemySearch;
    [SerializeField] EnemyCanAttack _enemyCanAttack;

    bool canMove = false;
    bool _finishCoolDown = true;


    Vector3 initPosition, playPos, enePos;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        playPos = Player.transform.position;

        _enemySearch.EnemyMove.Subscribe(value => { canMove = value; StartCoroutine("Action"); });

       //this.UpdateAsObservable().Where(_ => canMove).Subscribe(_ => Action());
    }

    // Update is called once per frame


    //void Action()
    //{
    //    //Debug.Log(enePos);
    //    playPos = Player.transform.position;
    //    enePos = transform.position;

    //    _isDownHorizontal.OnNext(0);

    //    if (Mathf.Abs(enePos.x - playPos.x) <= attackArea) //?U?????????????U??????        
    //    {
    //        Debug.Log("kougeki");
    //        _DownKey.OnNext("K");
    //    }
    //    else
    //    {
    //        Debug.Log("gogogog" + (enePos.x - playPos.x));
    //        GoPlayer();
    //    }

    //}

    //public void ReturnPos()
    //{
    //    if ((enePos.x - initPosition.x) < -posArea)
    //    {
    //        _isDownHorizontal.OnNext(1);
    //    }
    //    else if ((enePos.x - initPosition.x) > posArea)
    //    {
    //       _isDownHorizontal.OnNext(-1);
    //    }
    //    else
    //       _isDownHorizontal.OnNext(0);
    //}

    public void GoPlayer()
    {
        if (Math.Abs(enePos.x - playPos.x) > 1)
            if(enePos.x - playPos.x < 0)
                _isDownHorizontal.OnNext(1);
            else
               _isDownHorizontal.OnNext(-1);
    }
    IEnumerator Action()
    {
        while (canMove)
        {
            //Debug.Log(enePos);
            yield return new WaitForSeconds(0.1f);
            playPos = Player.transform.position;
            enePos = transform.position;


            if (_enemyCanAttack.getCanAttack() && _finishCoolDown)
            {
                _DownKey.OnNext("Z");
                _finishCoolDown = false;
               StartCoroutine("CoolTime");
            }
            else
            {
                //Debug.Log("go" + (enePos.x - playPos.x));
                GoPlayer();
            }
        }

    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(4f);
        //Debug.Log("クールタイムが終わった");
        _finishCoolDown = true;

    }


}