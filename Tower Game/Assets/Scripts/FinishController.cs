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
        // ��������� ������� GameOver � ������ ����� ���� ����/����� � ��
        Debug.Log("It's finish");
    }
}
