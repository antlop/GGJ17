using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButtonInput : MonoBehaviour {

	private GameObject playerObject;
	private bool pressed = false;
	public float intense = 0.0f;
	public float limitDistance = 5.0f;
	public KeyCode codeToCheckFor;
	private float permaIntense;


	private Vector3 result;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		permaIntense = intense;
		intense = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (codeToCheckFor)) {
			playerObject.GetComponent<AudioSource> ().Play ();
		}
		if (Input.GetKey (codeToCheckFor)) {
			playerObject.GetComponent<Rigidbody> ().useGravity = false;
			intense = permaIntense;
			pressed = true;
		}

		if (Input.GetKeyUp (codeToCheckFor)) {
			intense = 0.0f;
			playerObject.GetComponent<Rigidbody> ().useGravity = true;
			pressed = false;
		}
		
		if (pressed) {
		} else if (playerObject.transform.position.y <= 0) {
			intense = 0.0f;
		} else if ( intense > -5.0f) {
			//intense -= 10.0f * Time.deltaTime;
		}
	}

	public void PressedInput(float intense) {
		playerObject.GetComponent<Rigidbody> ().useGravity = false;
		this.intense = intense;
		permaIntense = intense;
		pressed = true;
		playerObject.GetComponent<AudioSource> ().Play ();
	}

	public void ReleasedInput() {
		intense = 0.0f;
		playerObject.GetComponent<Rigidbody> ().useGravity = true;
		pressed = false;
	}
}
