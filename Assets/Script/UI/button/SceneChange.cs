using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeSceneTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void ChangeSceneMain()
    {
        SceneManager.LoadScene("main");
    }
}
