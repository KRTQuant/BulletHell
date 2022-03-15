using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadGameplay()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadOption()
    {
        //fake function, just for make it seem like i code a lot. XD
        //SceneManager.LoadScene("Option");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
