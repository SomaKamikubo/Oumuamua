using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] GameObject HP1;
    [SerializeField] GameObject HP2;
    [SerializeField] GameObject HP3;

    //あほコード
    public void ViewHurt(int hp)
    {
        if (hp == 2)
        {
            HP3.SetActive(false);
        }
        if (hp == 1)
        {
            HP2.SetActive(false);
        }
        if (hp == 0)
        {
            HP1.SetActive(false);
        }
    }
}
