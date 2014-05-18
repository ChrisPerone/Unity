using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	public GameObject asteroidPrefab;
	public int numAsteroids = 10;

	// Use this for initialization
	void Start () {
		print ("Start");
		for (int i = 0; i < numAsteroids; ++i) {
			Vector3 spawnPos = new Vector3(Random.value * 10 - 5, Random.value * 10 - 5, 0);
			Instantiate (asteroidPrefab, spawnPos, Quaternion.Euler(Random.value, 0f, 0f));
		}
		GUI.Label (new Rect (20, 20, 100, 10), "Score:");
//		Destroy (gameObject);
	}
}
