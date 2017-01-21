using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironment : MonoBehaviour {

	public bool useRandomizedDeathZones = true;

	private float moveSpeed = 7.5f;

	private float bucket = 0.0f;
	private float bufferTime = 0.075f;
	private bool hasBeenScored = false;
	public Material deathMaterial;

	// Use this for initialization
	void Start () {
		if (useRandomizedDeathZones) {
			Transform[] transforms = GetComponentsInChildren<Transform> ();

			if (transforms.Length > 3) {
				int percentile = Random.Range (0, 100);

				if (percentile < 75) {
					int randIndex = Random.Range (1, transforms.Length - 1);
					Debug.Log (randIndex);
					transforms [randIndex].GetComponent<MeshRenderer> ().material = deathMaterial;
					transforms [randIndex].tag = "DeathField";
					transforms [randIndex].GetComponent<BoxCollider> ().isTrigger = true;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-moveSpeed * Time.deltaTime, 0, 0));

		if (GameObject.Find ("Spawner").GetComponent<SpawnerScript> ().spawnType == 3) {
			bucket += Time.deltaTime;
			//Debug.Log (bucket);
		}

		if (!hasBeenScored && transform.position.x < GameObject.Find ("Player").transform.position.x ) {
			GameObject.Find ("PlayerInfo").GetComponent<PlayerGeneralInfo> ().AddToScore (10);
			hasBeenScored = true;
		}

		if (transform.position.x <= -30.0f) {
			Destroy (gameObject);
		} else if( bucket >= bufferTime && GameObject.Find("Spawner").GetComponent<SpawnerScript>().spawnType == 3 ) {
			bucket = 0.0f;

			if (transform.position.x < GameObject.Find ("Player").transform.position.x + GameObject.Find ("Player").transform.localScale.x * 5.0f) {
				//transform.Translate (0, lastTranslateYValue, 0);
				return;
			}

			SpawnerScript spawner = GameObject.FindGameObjectWithTag ("Spawner").GetComponent<SpawnerScript>();

			float totalSound = 0.0f; 
			float percentile = 0.0f;
			for (int i = 0; i < spawner._freqBand.Length; ++i) {
				totalSound += spawner._freqBand [i];
			}

			percentile = Mathf.Min(totalSound / 40.0f, 1); //max found during play test. 

			float diff = 6.0f * percentile - transform.position.y;
			transform.Translate (0, diff, 0);
		}

	}
}
