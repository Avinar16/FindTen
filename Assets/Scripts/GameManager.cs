using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreCounter score_counter = new ScoreCounter();
    Timer timer;
    void Awake()
    {
        timer = gameObject.AddComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
