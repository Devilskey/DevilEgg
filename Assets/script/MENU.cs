using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    public GameObject howtoplayUI;
    public GameObject menuUI;


    public void instagram()
    {
        Application.OpenURL("https://www.instagram.com/devilskeystudio/?hl=nl");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void howtoplay()
    {
        howtoplayUI.SetActive(true);
        menuUI.SetActive(false);
    }
    public void howtoplayback()
    {
        howtoplayUI.SetActive(false);
        menuUI.SetActive(true);
    }

    public void play()
    {
        SceneManager.LoadScene(1);
    }
}
