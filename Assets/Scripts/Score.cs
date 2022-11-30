using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();

    }

    void Update()
    {
        score.text = scoreValue.ToString();
    }
    private IEnumerator Pulse()
    {
        for (float i = 1f; i <= 1.2f; i += 0.05f)
        {
            score.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        score.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        
        for (float i= 1.2f; i >= 1f; i -= 0.05f)
        {
            score.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        score.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void RunPulse()
    {
        StartCoroutine(Pulse());
    }

}
