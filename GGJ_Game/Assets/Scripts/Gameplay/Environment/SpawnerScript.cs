using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public float inspectingValue = 0.0f;
	public GameObject[] SpawnableObjectsInRange1;
	public GameObject[] SpawnableObjectsInRange2;
	public GameObject[] SpawnableObjectsInRange3;
	public GameObject[] SpawnableObjectsInRange4;
	public float spawnRate = 0.5f;
	public float max = 0.0f;
	public int spawnType = 0;

	private float[] _samples = new float[512];
	public float[] _freqBand = new float[8];
	private float[] _prevFreqBand = new float[8];
	private float[] _buffers =  new float[8];
	private GameObject camera;
	private float spawnBucket = 0.0f;

	// Use this for initialization
	void Start () {

		camera = GameObject.Find ("Main Camera");
		for (int i = 0; i < _buffers.Length; ++i) {
			_buffers [i] = spawnRate;
			_prevFreqBand [i] = 0.0f;
			_freqBand [i] = 0.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		getSpectrumAudioSource ();
		spawnBucket += Time.deltaTime;

		inspectingValue = _freqBand [1];

		switch (spawnType) {
		case 0:
			AttemptAtSpawningOne ();
			break;
		case 1:
			AttemptAtSpawningTwo ();
			break;
		case 2:
			AttemptAtSpawningThree ();
			break;
		case 3:
			SteadySpawning ();
			break;
		case 4:
			SteadySpawnPredesigned ();
			break;
		}

	}

	void SteadySpawnPredesigned() {
		if (spawnBucket >= spawnRate) {
			spawnBucket = 0.0f;

			Vector3 pos = transform.position;
			pos.y = -0.5f;

			int randomIndexToSpawn = Random.Range (0, SpawnableObjectsInRange4.Length);

			GameObject obj = Instantiate (SpawnableObjectsInRange4 [randomIndexToSpawn], pos, Quaternion.identity) as GameObject;

			Transform[] transforms = obj.GetComponentsInChildren<Transform> ();
			foreach (Transform trans in transforms) {

				if (trans.tag == "DeathField") {
					trans.gameObject.AddComponent<PulssateGlowEffect> ();
				}
			}

		}
	}

	void SteadySpawning() {

		if (spawnBucket >= spawnRate) {
			spawnBucket = 0.0f;

			Vector3 pos = transform.position;
			pos.y = -0.5f;

			GameObject obj = Instantiate (SpawnableObjectsInRange3 [0], pos, Quaternion.identity) as GameObject;
		}
	}

	void AttemptAtSpawningThree() {

		if (_freqBand[1] - _prevFreqBand[1] > 3.5f) {

			Vector3 pos = transform.position;
			pos.y = -0.5f;

			GameObject obj = Instantiate (SpawnableObjectsInRange3 [0], pos, Quaternion.identity) as GameObject;
		}

		for (int i = 0; i < _freqBand.Length; ++i) {
			_prevFreqBand[i] = _freqBand[i];
		}

	}

	void AttemptAtSpawningTwo() {

		float newtotal = 0.0f;
		float oldtotal = 0.0f;
		for (int i = 0; i < 3; ++i) {
			newtotal += _freqBand [i];
			oldtotal += _prevFreqBand [i];
		}

		if (newtotal - oldtotal > 4.0f) {

			Vector3 pos = transform.position;
			pos.y = -0.5f;

			GameObject obj = Instantiate (SpawnableObjectsInRange1 [0], pos, Quaternion.identity) as GameObject;
			//46
			obj.transform.localScale = new Vector3(obj.transform.localScale.x, 4*(newtotal / 20.0f), obj.transform.localScale.z);
			//4
		}

		for (int i = 0; i < _freqBand.Length; ++i) {
			_prevFreqBand[i] = _freqBand[i];
		}

	}

	void AttemptAtSpawningOne() {
		for (int i = 0; i < _freqBand.Length; ++i) {
			if (_freqBand [i] - _prevFreqBand [i] > 4.0f /*&& spawnBucket >= 0.15f*/) {

				spawnBucket /= 2;

				GameObject[] list = new GameObject[1];
				if (i / 2 == 0) {
					list = SpawnableObjectsInRange1;
				} else if (i / 2 == 1) {
					list = SpawnableObjectsInRange2;
				} else if (i / 2 == 2) {
					list = SpawnableObjectsInRange3;
				} else if (i / 2 == 3) {
					list = SpawnableObjectsInRange4;
				}


				int randomIndexToSpawn = Random.Range (0, list.Length);

				Vector3 pos = transform.position;
				pos.y = -0.5f;

				GameObject obj = Instantiate (list [randomIndexToSpawn], pos, Quaternion.identity) as GameObject;
			}
		}


		if (spawnBucket > spawnRate) {
			spawnBucket = 0.0f;

			int loudestIndex = -1;
			float loudestValue = 0.0f;
			for (int i = 0; i < _freqBand.Length; ++i) {
				if (_freqBand [i] > loudestValue) {
					loudestValue = _freqBand [i];
					loudestIndex = i;
				}

				if (_freqBand [i] > max) {
					max = _freqBand [i];
				}
			}

			Vector3 pos = transform.position;
			pos.y = -0.5f;

			GameObject obj = Instantiate (SpawnableObjectsInRange1 [0], pos, Quaternion.identity) as GameObject;
			//46
			obj.transform.localScale = new Vector3(obj.transform.localScale.x, 4*(loudestValue / max), obj.transform.localScale.z);
			//4
		}

		for (int i = 0; i < _freqBand.Length; ++i) {
			_prevFreqBand[i] = _freqBand[i];
		}
	}

	void getSpectrumAudioSource() {

		AudioSource aSource = camera.GetComponent<AudioSource> ();
		aSource.GetSpectrumData (_samples, 0, FFTWindow.Blackman);

		int count = 0; 
		for (int i = 0; i < 8; i++) {
			int sampleCount = (int)Mathf.Pow (2, i) * 2;
			float avg = 0;
			if( i == 7 ) {
				sampleCount += 2;
			}

			for (int j = 0; j < sampleCount; j++) {
				avg += _samples [count] * (count + 1);
				count++;
			}

			avg /= count;

			_freqBand[i] = avg * 10;
		}
	}
}
