using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerGeneralInfo : MonoBehaviour {

	static public int score = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddToScore(int amount) {
		score += amount;

		GameObject.Find ("Score").GetComponent<UnityEngine.UI.Text> ().text = "Score: " + score;
	}
}
