using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartButtonscript : MonoBehaviour
{
    public GameObject Main;
    public GameObject About;

    private void Start()
    {
        Main.SetActive(true);
        About.SetActive(false);
    }
    public void PlayGame()
    {
        Main.SetActive(false);
        About.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Main.SetActive(false);
        About.SetActive(false);
        Debug.Log("exiting game!!");
        Application.Quit();
    }

    /*public void PauseGame()
    {
        if (!panel.active)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }*/
    public void AboutMenu()
    {
        Main.SetActive(false);
        About.SetActive(true);
    }
    public void BackToMenu()
    {
        Main.SetActive(true);
        About.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
