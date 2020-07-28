using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int score = 0;

    [SerializeField] int bestScore = 0;
    string bestScoreName = "BestScore";

    private void Awake()
    {
        bestScore = PlayerPrefs.GetInt(bestScoreName, 0);
    }

    public int GetScore()
    {
        return score;
    }
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }
    public int GetBestScore()
    {
        return bestScore;
    }

    private void OnDestroy()
    {
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(bestScoreName, score);
        }
    }

}
