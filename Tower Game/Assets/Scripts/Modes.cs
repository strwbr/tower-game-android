using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modes : MonoBehaviour
{
    [SerializeField] private float time = 0f;

    private MyTimer timer = new MyTimer();
    private float minutes;
    private float seconds;


    private void Update()
    {


    }

    public void TimerModeHandler()
    {
        gameObject.SetActive(false);
        timer.StartTimer(time);
    }


}
