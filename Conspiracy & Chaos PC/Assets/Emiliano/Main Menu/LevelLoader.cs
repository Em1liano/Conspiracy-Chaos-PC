using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int timeToWait = 4;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(WaitForClickMainMenu());
    }
    public void LoadGameSession()
    {
        Time.timeScale = 1;
        StartCoroutine(WaitForClickMainGame());
    }
    public void LoadOptionsScene()
    {
        StartCoroutine(WaitForClickOptions());
    }
    public void LoadSoundScene()
    {
        StartCoroutine(WaitForClick());
    }
    public void LoadSaveMenu()
    {
        StartCoroutine(WaitForClickSave());
    }
    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    IEnumerator WaitForClickMainMenu()
    {
        AnalyticsResult result = Analytics.CustomEvent("Stworzenie nowej sesji gry");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(2);
    }
    IEnumerator WaitForClickOptions()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(3);
    }
    IEnumerator WaitForClickSave()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(4);
    }
    IEnumerator WaitForClick()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(5);
    }
    IEnumerator WaitForClickMainGame()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(6);
    }
}
