﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{
    public FixedJoystick leftJoystick;
    public FixedJoystick rightJoystick;

    public FixedButton button;

    protected ThirdPersonUserControl control;
    protected float cameraAngle;
    protected float cameraAngleSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<ThirdPersonUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        control.m_Jump = button.Pressed;
        control.hInput = leftJoystick.Horizontal;
        control.vInput = leftJoystick.Vertical;

        cameraAngle += rightJoystick.Horizontal * cameraAngleSpeed;

        Camera.main.transform.position = transform.position+ Quaternion.AngleAxis(cameraAngle, Vector3.up) * new Vector3(0, 3, 4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position+Vector3.up*2f-Camera.main.transform.position, Vector3.up);
    }
}
