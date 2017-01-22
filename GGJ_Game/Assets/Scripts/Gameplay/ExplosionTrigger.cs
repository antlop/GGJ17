using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour {

	public ParticleSystem esplosion;
	public ParticleSystem smoke;
	public ParticleSystem debris;

	// Use this for initialization
	void Start () {
		esplosion.startDelay -= 1.0f;
		smoke.startDelay -= 1.0f;
		debris.startDelay -= 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ExplodeMe() {
		GetComponent<AudioSource> ().Play ();
		esplosion.Play();
		smoke.Play();
		debris.Play();
	}
}
