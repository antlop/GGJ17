using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUIEndlessly : MonoBehaviour {

	public bool rotateLeft = false;
	public float rotateSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (rotateLeft) {
			transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed);
		} else {
			transform.Rotate (Vector3.forward * Time.deltaTime * -rotateSpeed);
		}
	}
}
