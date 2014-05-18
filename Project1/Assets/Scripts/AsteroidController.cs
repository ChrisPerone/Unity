using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

	public GameObject spawnPrefab;
	public float speed = 0.5f;
	private float angle;

	// Use this for initialization
	void Start () {
		angle = Random.value * Mathf.PI * 2;
		(renderer as SpriteRenderer).color = new Color (Mathf.Clamp(Random.value, 0.5f, 1f), Mathf.Clamp(Random.value, 0.5f, 1f), Mathf.Clamp(Random.value, 0.5f, 1f));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.forward, Random.value);
		rigidbody2D.velocity = new Vector2 (speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "prop_projectile_1(Clone)") {
			Destroy (col.gameObject);
			if (transform.localScale.sqrMagnitude > 3f) {
				for (int i = 0; i < 2; ++i) {
					Vector3 spawnPos = transform.position;
					spawnPos.x += Mathf.Cos(Random.value * Mathf.PI * 2) * 0.1f;
					spawnPos.y += Mathf.Sin(Random.value * Mathf.PI * 2) * 0.1f;
					GameObject clone = Instantiate(spawnPrefab, spawnPos, transform.rotation) as GameObject;
					clone.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
		//			clone.velocity = transform.TransformDirection (Vector3.right * 10);
				}
			}
			Destroy (gameObject);
		}
	}
}
