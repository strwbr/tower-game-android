using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRay : MonoBehaviour
{
    public event Action RayHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        Debug.DrawRay(transform.position, -transform.up * 5, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit smth");
            Debug.Log(hit.collider);

            RayHit.Invoke();
        }
    }
}
