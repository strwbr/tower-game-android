using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private bool isFirst = true;

    private PlatformRay platformRay;

    public static event Action Finish;

    private void Start()
    {
        platformRay = GetComponent<PlatformRay>();
        platformRay.RayHit += PlatformRay_RayHit;
    }

    private void PlatformRay_RayHit()
    {
        Destroy(GetComponent<PlatformRay>());
        isFirst = false;
        Debug.Log("Delete PlatformRay");
    }


    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Platform" && gameObject.tag == "Platform")
    //    {
    //        Debug.Log("isFirst = " + isFirst);
    //        if (isFirst)
    //        {
    //            Vector3 heading = other.transform.position - transform.position;
    //            float distance = heading.magnitude;
    //            Vector3 direction = heading / distance;
    //            Debug.Log($"direction = {direction}");
    //            if (direction.y < 0)
    //            {
    //                Debug.Log($"Контакт произошел");
    //                isFirst = false;
    //            }
    //        }
    //        else Debug.Log("НЕ верхний");
    //    } 
    //    else
    //    {
    //        Finish?.Invoke();
    //        Debug.Log($"Не соприкоснулись");
    //    }
    //}
}
