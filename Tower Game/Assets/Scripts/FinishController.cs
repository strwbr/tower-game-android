using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private void Start()
    {
        PlatformController.Finish += Finish;
    }

    private void Finish()
    {
        // появление канваса GameOver с нужной инфой типа счет/время и тд
        Debug.Log("It's finish");
    }
}
