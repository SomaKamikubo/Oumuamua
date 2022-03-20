using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{

    [SerializeField] GameObject menu;
    public void OnButtonPressed()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

}
