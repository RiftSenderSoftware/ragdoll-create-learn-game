using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuadroSceneLoader : MonoBehaviour
{
    public void MainSceneLoad()
    {
        SceneManager.LoadScene(4);
    }
    public void FirstSceneLoad()
    {
        SceneManager.LoadScene(3);
    }
    public void SecondSceneLoad()
    {
        SceneManager.LoadScene(5);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
