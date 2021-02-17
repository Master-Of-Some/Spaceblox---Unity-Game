using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartSceneOne()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene(1);
    }

   /* public void ContinueGame()            This is the continue/restart level method 
    {
        
    } 
   */
}
