using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string mainMenu,nextlevel,level1;

    public GameObject ayarlarMenusu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ayarlarMenusu.SetActive(true);
        }



    }
    public void Newgame() 
    {
        SceneManager.LoadScene(level1);
    }
    public void Nextlevel()
    {
        SceneManager.LoadScene(nextlevel);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void winGame()
    {
        gameObject.SetActive(true);
    }

}
