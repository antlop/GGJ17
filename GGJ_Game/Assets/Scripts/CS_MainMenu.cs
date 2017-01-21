using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_MainMenu : MonoBehaviour {

    public string LevelNameToLoad;

	public int currentIndex = 0;
	public Texture2D[] cursorAnimations;

	private float bucket = 0.0f;
	private float interval = 0.1f;
	private bool shouldAnimate = false;

	void Start() {
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			currentIndex = 0;
			shouldAnimate = true;
		}

		bucket += Time.deltaTime;

		if (shouldAnimate) {

			if (++currentIndex > cursorAnimations.Length) {
				shouldAnimate = false;
				Debug.Log ("Stopping Anim");
				currentIndex = 0;
				Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
			} else if (bucket >= interval) {
				bucket = 0; 
				Vector2 offset = new Vector2 (cursorAnimations [++currentIndex].width / 2, cursorAnimations [++currentIndex].height / 2);
				Cursor.SetCursor (cursorAnimations [++currentIndex], offset, CursorMode.Auto);
			}
		}
	}

    public void StartGame()
    {
		SceneManager.LoadScene(LevelNameToLoad, LoadSceneMode.Single);
    }
}
