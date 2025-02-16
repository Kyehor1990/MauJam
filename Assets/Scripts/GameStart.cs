using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string mainMenu, nextlevel, level1 = "level1";
    public TextMeshProUGUI win, lose;
    bool winmi = false, losemu = false;

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
        if (!losemu)
        {
            ayarlarMenusu.SetActive(true);
            Time.timeScale = 0f;
            win.text = "Next Level";
            winmi = true;
        }
    }
    public void loseGame()
    {
        if (!winmi)
        {
            ayarlarMenusu.SetActive(true);
            Time.timeScale = 0f;
            lose.text = "Try Again";
            losemu = true;
        }
    }
    public void Newgame()
    {
        SceneManager.LoadScene(level1);
    }
    public void Nextlevel()
    {
        Debug.Log("deneme");
        Time.timeScale = 1f;
        if (winmi) { Time.timeScale = 1f; Debug.Log("kazandýn"); SceneManager.LoadScene(nextlevel); }
        else if (losemu) { Time.timeScale = 1f; Debug.Log("çalýþtý"); SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
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

    private void Start()
    {
        Time.timeScale = 1f;
    }
}
