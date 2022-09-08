using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMode : MonoBehaviour
{
    [SerializeField] private float roundTime = 5f;
    [SerializeField] private GameObject finish;

    private MyTimer timer;

    private void Start()
    {
        timer = finish.gameObject.AddComponent<MyTimer>();
    }

    public void TimerModeHandler()
    {
        gameObject.SetActive(false);
        timer.StartTimer(roundTime);
    }
}
