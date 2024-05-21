using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter
{
    int Record;
    int Score;
    public void setScore(int score)
    {
        Score += score;
    }
    public void setRecord()
    {
        if(Score > Record)
        {
            Record = Score;
        }
    }
}
