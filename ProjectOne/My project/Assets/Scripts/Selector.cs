using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    public void Selec()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
