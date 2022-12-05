using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public RawImage img;

    public void gameStart()
    {
        SceneManager.LoadScene(2);
    }
    public void Informacje()
    {
        SceneManager.LoadScene(3);
    }
    public void Wyjscie()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
