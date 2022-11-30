using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

        public void SetUp(int score)
    {
        gameObject.SetActive(true);
        score = Score.scoreValue;
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        Score.scoreValue = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }


}
