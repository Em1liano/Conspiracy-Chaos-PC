using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreDisplay : MonoBehaviour
{
    Text bestScore;
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = GetComponent<Text>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        bestScore.text = "Best score: " + gameController.GetBestScore().ToString();
    }
}
