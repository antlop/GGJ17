using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("Score").GetComponent<UnityEngine.UI.Text> ().text = PlayerGeneralInfo.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void backToMainMenu() {
		Application.LoadLevel("MainMenu");
	}
}
