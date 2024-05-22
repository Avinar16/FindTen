using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private float StartTime;
    [SerializeField]
    private TextMeshProUGUI text;

    private bool isActive;
    private void Update()
    {
        TimerTick();
    }
    void OnTimer()
    {
        isActive = false;
        GameManager.gameManager.EndGame();
    }
    public void StartTimer()
    {
        timer = StartTime;
        isActive = true;
    }
    void TimerTick()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            text.SetText(Math.Round(timer).ToString());
        }
        if (timer <= 0)
        {
            OnTimer();
        }
    }
}
