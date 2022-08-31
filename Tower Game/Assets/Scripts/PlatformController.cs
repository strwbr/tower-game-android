using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private bool isFirst = true;

    public static event Action Finish;

    private void Update()
    {
        //if(transform.rotation.y )
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform" && gameObject.tag == "Platform")
        {
            Debug.Log("isFirst = " + isFirst);
            if (isFirst)
            {
                Vector3 heading = other.transform.position - transform.position;
                float distance = heading.magnitude;
                Vector3 direction = heading / distance;
                Debug.Log($"direction = {direction}");
                if (direction.y < 0)
                {
                    Debug.Log($"Контакт произошел");
                    isFirst = false;
                }
            }
            else Debug.Log("НЕ верхний");
        } 
        else
        {
            Finish?.Invoke();
            Debug.Log($"Не соприкоснулись");
        }
    }
}
