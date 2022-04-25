using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Boss2Input :CharactorInput
{


    void Start()
    {
        StartCoroutine("Action");
    }
    IEnumerator Action()
    {
        //Žn‚ß‚Í”½‰ž‚µ‚È‚¢‚½‚ß1•b‚Ü‚Â
        yield return new WaitForSeconds(1f);
        _DownKey.OnNext("Z");
        Debug.Log("boss2attack");
        while (true)
        {
            _DownKey.OnNext("Z");
            Debug.Log("boss2attack");
            yield return new WaitForSeconds(10f);
            
        }
    }

}
