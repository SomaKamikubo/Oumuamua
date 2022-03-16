using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float attackArea; //���͈̔͂ɗ�����U��
    [SerializeField] float moveArea;  //�s���ł���͈�
    [SerializeField] float searchArea; //�s���J�n����͈�
    [SerializeField] float posArea;  //�ҋ@��Ԃ͈̔́iinitPos�͈̔͂��L����j
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
        
        

        GoPlayer(); //�U�����̐U������p�Ƃ��Ă��g�p����

        if (Mathf.Abs(initPosition.x - playPos.x) <= attackArea) //�U���͈͓��ɗ�����U������        
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
