using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulssateGlowEffect : MonoBehaviour {

	float pulsingScale = 0.1f;
	bool increasing = true;
	// Use this for initialization
	void Start () {

		pulsingScale = Random.Range (0.1f, 0.9f);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (increasing) {
			pulsingScale += Time.deltaTime * 5.0f;
			if (pulsingScale >= 1.5f) {
				pulsingScale = 1.5f;
				increasing = false;
			}
		} else {
			pulsingScale -= Time.deltaTime * 7.5f;
			if (pulsingScale <= 0.1f) {
				pulsingScale = 0.1f;
				increasing = true;
			}
		}

		Debug.Log (pulsingScale);
		GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", new Color (204.0f/255.0f, 115.0f/255.0f, 51.0f/255.0f) * pulsingScale);
		//DynamicGI.SetEmissive (GetComponent<Renderer> (), new Color (204, 115, 51) * pulsingScale);
	}
}
