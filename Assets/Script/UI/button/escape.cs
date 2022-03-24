using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour
{
    [SerializeField]  GameObject menu;
    public void OnButtonPressed()
    {
        Time.timeScale = 1;
        menu.SetActive(false);

    }
}
