using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("mainScene");
    }
    public void play2()
    {
        SceneManager.LoadScene("mainSceneCoop");
    }
}
