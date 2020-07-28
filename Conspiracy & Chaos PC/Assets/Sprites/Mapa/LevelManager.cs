using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public int SceneIndex;
    void Start()
    {
        Invoke("LoadingFunction", 5f);
    }
    void LoadingFunction()
    {
        SceneManager.LoadSceneAsync(SceneIndex);
    }
}
