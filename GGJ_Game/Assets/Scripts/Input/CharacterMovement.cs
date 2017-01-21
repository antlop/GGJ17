using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float AppliedDistanceFromGround = 0.0f;
	public float buffer = 0.5f;
	SingleButtonInput[] buttons; 

	// Use this for initialization
	void Start () {
		buttons = GameObject.FindObjectsOfType<SingleButtonInput> ();	
	}
	
	// Update is called once per frame
	void Update () {

		AppliedDistanceFromGround = 0.0f;
		foreach (SingleButtonInput buttonInput in buttons) {
			AppliedDistanceFromGround += buttonInput.intense;
		}
		if (AppliedDistanceFromGround == 0)
			return;
		Vector3 destination = new Vector3(0, AppliedDistanceFromGround, 0);
		destination -= transform.position;

		int signed = 1;
		if (destination.y < 0)
			signed = -1;
		destination.y *= destination.y * signed;
		if (destination.y < 2.0f && destination.y > 0.01f) {
			destination.y = 2.0f;
		}
		transform.GetComponent<Rigidbody> ().velocity = destination;
	}
}
