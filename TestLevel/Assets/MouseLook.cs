﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	[HideInInspector]
	public float xRotation;
	[HideInInspector]
	public float yRotation;
	public float lookSentivity = 5;
	[HideInInspector]
	public float currXRotation;
	[HideInInspector]
	public float currYRotation;
	[HideInInspector]
	public float xRotationVelocity;
	[HideInInspector]
	public float yRotationVelocity;
	public float smoothDampTime = 0.1f;

	// Update is called once per frame
	void Update () {
		xRotation -= Input.GetAxis ("Mouse Y") * lookSentivity;
		yRotation += Input.GetAxis ("Mouse X") * lookSentivity;

		xRotation = Mathf.Clamp (xRotation, -90, 90); 

		currXRotation = Mathf.SmoothDamp (currXRotation, xRotation, ref xRotationVelocity, smoothDampTime);
		currYRotation = Mathf.SmoothDamp (currYRotation, yRotation, ref yRotationVelocity, smoothDampTime);


		transform.rotation = Quaternion.Euler (currXRotation, currYRotation, 0);
	}
}
