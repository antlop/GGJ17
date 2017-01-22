using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunamiCodeDetection : MonoBehaviour {

	char[] kunamiCode;
	Queue<KeyCode> inputCodes = new Queue<KeyCode>();

	// Use this for initialization
	void Start () {
		//kunamiCode = new char[];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey ) {
			foreach (char c in Input.inputString) {
			
				Debug.Log (c);
			}
		}
	}
}
