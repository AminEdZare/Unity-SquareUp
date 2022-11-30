using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    int score = Score.scoreValue;

    public void GameOver()
    {
        GameOverScreen.SetUp(score);
    }
}

