using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBobbin : MonoBehaviour {

	float rotationAngle = 0.0f;

	float backwardRotationAngle = -0.03f;
	float forwardRotationAngle = 0.03f;
	bool noddingForward = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (noddingForward) {
			rotationAngle += 0.123f * Time.deltaTime;

			if (rotationAngle >= forwardRotationAngle) {
				noddingForward = false;
				rotationAngle = 0.0f;
			}
		} else {
			rotationAngle -=  0.123f * Time.deltaTime;

			if (rotationAngle <= backwardRotationAngle) {
				noddingForward = true;
				rotationAngle = 0.0f;
			}
		}

		transform.RotateAround (new Vector3 (0, 0, 1), rotationAngle);
	}
}
