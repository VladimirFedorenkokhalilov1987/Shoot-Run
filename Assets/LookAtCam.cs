using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Camera cameraToLookAt;

    private void Start()
    {
        cameraToLookAt = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0;
        transform.LookAt(cameraToLookAt.transform.position-v);
        transform.Rotate(0,180,0);
    }
}
