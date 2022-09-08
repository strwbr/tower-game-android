using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    private float _time;
    private float _timeLeft;
    private bool _timerOn = false;

    public MyTimer()
    {
        _time = 5;
        _timeLeft = _time;
    }

    public MyTimer(float time)
    {
        _time = time;
        _timeLeft = _time;
    }

    private void Update()
    {
        if(_timerOn)
        {
            Timer();
        }
    }

    public void StartTimer(float time)
    {
        _time = time;
        _timeLeft = _time;
        _timerOn = true;
        Debug.Log("START timer!");
    }

    private void StopTimer()
    {
        _timerOn = false;
        Debug.Log("STOP timer!");
    }

    private void Timer()
    {
        if (_timeLeft > 0f)
        {
            _timeLeft -= Time.deltaTime;
            PrintTime();
        }
        else
        {
            StopTimer();
            _timeLeft = _time;
        }
    }

    private void PrintTime()
    {
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        Debug.Log(string.Format("{0:00} : {1:00}", minutes, seconds));
    }
}
