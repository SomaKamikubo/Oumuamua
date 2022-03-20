using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_title : MonoBehaviour
{

    public void OnButtonPressed()
    {
        SceneManager.LoadScene("Title");
    }
}
