using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("Score").GetComponent<UnityEngine.UI.Text> ().text = PlayerGeneralInfo.score.ToString();
		PlayerGeneralInfo.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void backToMainMenu() {
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
}
