using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //trtt
    public void StartGame()
    {
        SceneManager.LoadScene("Test_Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

