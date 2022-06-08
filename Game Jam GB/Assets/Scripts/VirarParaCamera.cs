using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirarParaCamera : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
            cam = player.GetComponentInChildren<Camera>();
    }

    private void Update()
    {        
        if (cam != null)
        {
            Vector3 posCalc = cam.transform.position - transform.position;

            posCalc.x = posCalc.z = 0.0f;
            transform.LookAt(cam.transform.position - posCalc);
            transform.Rotate(0, 180, 0);
        }
    }
}
