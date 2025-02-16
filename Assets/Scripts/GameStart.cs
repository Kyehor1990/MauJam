using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string mainMenu, nextlevel, level1 = "";
    public TextMeshProUGUI win,lose;
    bool winmi = false,losemu = false;

    public GameObject ayarlarMenusu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ayarlarMenusu.SetActive(true);
            Time.timeScale = 0f;
        }



    }

    public void winGame()
    {
        ayarlarMenusu.SetActive(true);
        Time.timeScale = 0f;
        win.text = "Next Level";
        winmi = true;
    }
    public void loseGame()
    {
        ayarlarMenusu.SetActive(true);
        Time.timeScale = 0f;
        lose.text = "Try Again";
        losemu = true;
    }
    public void Newgame()
    {
        SceneManager.LoadScene(level1);
    }
    public void Nextlevel()
    {
        Time.timeScale = 1f;
        if (winmi) { SceneManager.LoadScene(nextlevel); Time.timeScale = 1f; }
        else if (losemu) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); Time.timeScale = 1f; }
        else
        {
            ayarlarMenusu.SetActive(false);
            Time.timeScale = 1f;
        }


    }
    public void mainmenu()
    {
        SceneManager.LoadScene(mainMenu);
    }


}
