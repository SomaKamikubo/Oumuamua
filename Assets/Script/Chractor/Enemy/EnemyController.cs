using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float attackArea; //????????????U??
    [SerializeField] float moveArea;  //?s?????????
    [SerializeField] float searchArea; //?s???J?n??????
    [SerializeField] float posArea;  //??@??????iinitPos??????L????j
    [SerializeField] GameObject Player;


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
    }

    // Update is called once per frame
    void Update()
    {
        playPos = Player.transform.position;
        enePos = transform.position;

        if (Mathf.Abs(initPosition.x - playPos.x) > searchArea)
            ReturnPos();
        else
            Action();

    }

    public void Action()
    {

       _isDownHorizontal.OnNext(0);

        if ((enePos.x <= (initPosition.x - moveArea)) || (enePos.x >= (initPosition.x + moveArea)))
            if ((playPos.x <= (initPosition.x - moveArea)) || (playPos.x >= (initPosition.x + moveArea)))
            {
               _isDownHorizontal.OnNext(0);
                return;
            }



        //?U??????U??????p???????g?p????

        if (Mathf.Abs(enePos.x - playPos.x) <= attackArea) //?U?????????????U??????        
        {
            _DownKey.OnNext("K");
        }
        else
        {
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