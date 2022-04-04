using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float attackArea; //????????????U??
    [SerializeField] float posArea;  //??@??????iinitPos??????L????j
    [SerializeField] GameObject Player;
    [SerializeField] EnemySearch _enemySearch;

    bool canMove = false;


    Subject<string> _DownKey = new Subject<string>();
    Subject<float> _isDownHorizontal = new Subject<float>();

    public IObservable<string> OnDownKey { get { return _DownKey; } }
    public IObservable<float> OnDownHorizontalKey { get { return _isDownHorizontal; } }



    Vector3 initPosition, playPos, enePos;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        playPos = Player.transform.position;

        _enemySearch.EnemyMove.Subscribe(value => canMove = value);

        this.UpdateAsObservable().Where(_ => canMove).Subscribe(_ => Action());
    }

    // Update is called once per frame


    public void Action()
    {
        //Debug.Log(enePos);
        playPos = Player.transform.position;
        enePos = transform.position;

        _isDownHorizontal.OnNext(0);

        if (Mathf.Abs(enePos.x - playPos.x) <= attackArea) //?U?????????????U??????        
        {
            Debug.Log("kougeki");
            _DownKey.OnNext("K");
        }
        else
        {
            Debug.Log("gogogog"+ (enePos.x - playPos.x));
            GoPlayer();
        }



    }

    public void ReturnPos()
    {
        if ((enePos.x - initPosition.x) < -posArea)
        {
            _isDownHorizontal.OnNext(1);
        }
        else if ((enePos.x - initPosition.x) > posArea)
        {
           _isDownHorizontal.OnNext(-1);
        }
        else
           _isDownHorizontal.OnNext(0);
    }

    public void GoPlayer()
    {
        if ((enePos.x - playPos.x) < 0)
           _isDownHorizontal.OnNext(1);
        else
           _isDownHorizontal.OnNext(-1);
    }


}