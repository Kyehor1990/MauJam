using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string mainMenu,nextlevel,level1;
    public TextMeshProUGUI win;
    bool winmi=false;

    public GameObject ayarlarMenusu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ayarlarMenusu.SetActive(true);
        }



    }
     public void winGame()
    {
        ayarlarMenusu.SetActive(true);
        win.text = "Next Level";
        winmi = true;
    }public void Newgame() 
    {
        SceneManager.LoadScene(level1);
    }
    public void Nextlevel()
    {
        
        if (winmi) {SceneManager.LoadScene(nextlevel);}
        else { ayarlarMenusu.SetActive(false); }

    }
    public void mainmenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
   

}
