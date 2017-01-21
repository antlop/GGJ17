using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("collidedwithtrigger");
		if (other.tag == "DeathField") {
			playerDied ();
			Debug.Log ("loadDeathScreen");
		} else if (other.tag == "PlayerWinField") {
			playerWon ();
		}
	}

	void playerDied() {
		Application.LoadLevel ("DeathScreen");
	}

	void playerWon() {
	}
}
