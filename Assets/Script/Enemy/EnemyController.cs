using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float attackArea; //この範囲に来たら攻撃
    [SerializeField] float moveArea;  //行動できる範囲
    [SerializeField] float searchArea; //行動開始する範囲
    [SerializeField] float posArea;  //待機状態の範囲（initPosの範囲を広げる）
    [SerializeField] GameObject Player;
    [SerializeField] EnemyView input_view;





    Vector3 initPosition,playPos,enePos;

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
        if ((enePos.x <= (initPosition.x - moveArea)) || (enePos.x >= (initPosition.x + moveArea)))
            if ((playPos.x <= (initPosition.x - moveArea)) || (playPos.x >= (initPosition.x + moveArea)))
            {
                input_view.InputIdle();
                return;
            }
        
        

        GoPlayer(); //攻撃時の振り向き用としても使用する

        if (Mathf.Abs(initPosition.x - playPos.x) <= attackArea) //攻撃範囲内に来たら攻撃する        
            input_view.InputX();

            

    }

    public void ReturnPos()
    {
        if((enePos.x - initPosition.x) < -posArea)
        {
            input_view.InputRight();
        }

        if ((enePos.x - initPosition.x) > posArea)
        {
            input_view.InputLeft();
        }
    }

    public void GoPlayer()
    {
        if ((enePos.x - playPos.x) < 0)
            input_view.InputRight();
        else
            input_view.InputLeft();
    }


}
