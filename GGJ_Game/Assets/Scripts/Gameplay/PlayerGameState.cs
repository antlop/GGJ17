using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameState : MonoBehaviour {

	public bool hasDied = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "DeathField") {
			playerDied ();
			Debug.Log ("loadDeathScreen");
		} else if (other.tag == "PlayerWinField") {
			playerWon ();
		}
	}

	void playerDied() {
		hasDied = true;
		GetComponentInChildren<ExplosionTrigger>().ExplodeMe();

		this.Invoke("changeSceneAfterDeath",4.0f);
	}

	void changeSceneAfterDeath() {
		SceneManager.LoadScene ("DeathScreen", LoadSceneMode.Single);
	}

	void playerWon() {
	}
}
