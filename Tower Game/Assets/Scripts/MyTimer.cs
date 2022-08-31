using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    private bool _timerOn = false;

    public float TimeLeft { get; private set; }

    public MyTimer()
    {
        TimeLeft = 0f;
    }

    private void Update()
    {
        if (_timerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                PrintTime();
            }
            else
            {
                TimeLeft = 0;
                _timerOn = false;
            }
        }
    }

    private void PrintTime()
    {
        float minutes = Mathf.FloorToInt(TimeLeft / 60);
        float seconds = Mathf.FloorToInt(TimeLeft % 60);
        Debug.Log(string.Format("{0:00} : {1:00}", minutes, seconds));
    }

    public void StartTimer(float time)
    {
        TimeLeft = time;
        _timerOn = true;
    }
}
