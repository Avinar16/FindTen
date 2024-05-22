using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    int Record;
    int Score = 0;
    private void Start()
    {
        text.SetText(Score.ToString());
    }
    public void AddScore(int score)
    {
        Score += score;
        text.SetText(Score.ToString());
    }
    public void ResetScore()
    {
        Score = 0;
        text.SetText(Score.ToString());
    }
    public void SetRecord()
    {
        if(Score > Record)
        {
            Record = Score;
        }
    }
}
