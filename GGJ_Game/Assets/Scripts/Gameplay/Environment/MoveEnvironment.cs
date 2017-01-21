using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironment : MonoBehaviour {

	private float moveSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-moveSpeed * Time.deltaTime, 0, 0));

		if (transform.position.x <= -30.0f) {
			Destroy (gameObject);
		}
	}
}
