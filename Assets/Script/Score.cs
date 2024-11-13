using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    private float timeScore = 0.0f;
    int TotalScore;

    public TextMeshProUGUI TotalScoreTxt;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int score)
        //매게변수 int score는 외부에서 받아올수 있음
    {
        TotalScore += score;
        TotalScoreTxt.text = TotalScore.ToString();
    }

    void Update()
    {
        timeScore += Time.deltaTime;

        if (timeScore >= 5f)
        {
            TotalScore += 10;
            timeScore = 0f;
            TotalScoreTxt.text = TotalScore.ToString();
        }
    }
}
