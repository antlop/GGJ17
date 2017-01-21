using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButtonInput : MonoBehaviour {

	private GameObject playerObject;
	private bool pressed = false;
	public float intense = 0.0f;
	public float limitDistance = 5.0f;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed) {
		} else if (playerObject.transform.position.y <= 0) {
			intense = 0.0f;
		} else if ( intense > -5.0f) {
			//intense -= 10.0f * Time.deltaTime;
		}
	}

	public void PressedInput(float intensity) {
		playerObject.GetComponent<Rigidbody> ().useGravity = false;
		intense = intensity;
		pressed = true;
	}

	public void ReleasedInput() {
		intense = 0.0f;
		playerObject.GetComponent<Rigidbody> ().useGravity = true;
		pressed = false;
	}
}
