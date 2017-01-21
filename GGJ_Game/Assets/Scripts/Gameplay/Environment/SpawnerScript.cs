using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public GameObject[] SpawnableObjectsInRange1;
	public GameObject[] SpawnableObjectsInRange2;
	public GameObject[] SpawnableObjectsInRange3;
	public GameObject[] SpawnableObjectsInRange4;
	public float spawnRate = 0.5f;
	public float max = 0.0f;

	private float[] _samples = new float[512];
	public float[] _freqBand = new float[8];
	private float[] _buffers =  new float[8];
	private GameObject camera;
	private float spawnBucket = 0.0f;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		for (int i = 0; i < _buffers.Length; ++i) {
			_buffers [i] = spawnRate;
		}
	}
	
	// Update is called once per frame
	void Update () {

		getSpectrumAudioSource ();

		spawnBucket += Time.deltaTime;

		/*if (/*spawnBucket >= spawnRate || (_freqBand[1] > 3.0f && spawnBucket >= 0.5f) ) {
			spawnBucket = 0.0f;

			int randomIndexToSpawn = Random.Range (0, SpawnableObjects.Length);

			Vector3 pos = transform.position;
			pos.y = -0.5f;

			GameObject obj = Instantiate (SpawnableObjects [randomIndexToSpawn], pos, Quaternion.identity) as GameObject;
		}*/
		float total = 0.0f;
		for (int i = _freqBand.Length - 1; i >= 0; i--) {
			total += _freqBand [i];

		}
		if (total > max) {
			max = total;
			// 47
		}


		/*Vector3 pos = transform.position;
		pos.y = -0.5f;
		int randomIndexToSpawn = Random.Range (0, list.Length);
		GameObject obj = Instantiate (SpawnableObjectsInRange1[randomIndexToSpawn], pos, Quaternion.identity) as GameObject;
		obj.transform.localScale.y

		/*for (int i = _freqBand.Length -1; i >= 0 ; i-=2) {
			if ((_freqBand [i] > 3.0f || _freqBand [i - 1] > 3.0f) && spawnBucket >= spawnRate ) {
				spawnBucket = 0.0f;

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

				Vector3 pos = transform.position;
				pos.y = -0.5f;
				int randomIndexToSpawn = Random.Range (0, list.Length);
				GameObject obj = Instantiate (list [randomIndexToSpawn], pos, Quaternion.identity) as GameObject;
				obj.transform.localScale.y
				//3.8 max minimum 0.5
				break;
			}
		}*/
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
