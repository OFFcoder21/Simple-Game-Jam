using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGamemenu : MonoBehaviour
{
    public GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }

    public void LeaveGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
