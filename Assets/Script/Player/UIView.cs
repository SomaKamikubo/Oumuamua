using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] GameObject HP1;
    [SerializeField] GameObject HP2;
    [SerializeField] GameObject HP3;

    //Ç†ÇŸÉRÅ[Éh
    public void ViewHurt(int hp)
    {
        if (hp == 3)
        {
            HP3.SetActive(false);
        }
        if (hp == 2)
        {
            HP2.SetActive(false);
        }
        if (hp == 1)
        {
            HP1.SetActive(false);
        }
    }
}
