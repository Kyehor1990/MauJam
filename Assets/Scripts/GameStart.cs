using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string level1;
    public string mainMenu;
    public string nextlevel;
    void Update()
    {



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

}
