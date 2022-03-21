using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void OnButtonPressed()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
