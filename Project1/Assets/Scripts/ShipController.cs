using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public Rigidbody2D projectile;
	[Range(20f, 0f)]
	public float maxThrust 	= 5f;
	public float maxRot 	= 10f;
	public float fireRate 	= 0.001f;
	private float nextFireTime;

	// Use this for initialization
	void Start () {
		nextFireTime = 0f;
	}
	
	void FixedUpdate () {
//		angle += -Input.GetAxis ("Horizontal");
		float thrustX = Mathf.Clamp(Input.GetAxis ("Horizontal"), -1f, 1f);
		float thrustY = Mathf.Clamp(Input.GetAxis ("Vertical"), -1f, 1f);
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, pos - transform.position);
		transform.Rotate (new Vector3 (0, 0, 90f));
		Vector3 eulerRot = transform.rotation.eulerAngles;
		rigidbody2D.velocity = new Vector2 (thrustX * maxThrust, thrustY * maxThrust); // * Mathf.Cos(angle * Mathf.Deg2Rad), thrust * maxThrust * Mathf.Sin(angle * Mathf.Deg2Rad));

		if (Input.GetButton("Fire1")) { // && Time.fixedTime >= nextFireTime) {
			nextFireTime = Time.fixedTime + fireRate;
			Vector3 spawnPos = transform.position;
			spawnPos.x += Mathf.Cos(eulerRot.z * Mathf.Deg2Rad) * 0.2f;
			spawnPos.y += Mathf.Sin(eulerRot.z * Mathf.Deg2Rad) * 0.2f;
			Instantiate(projectile, spawnPos, transform.rotation); // as Rigidbody2D;
//			clone.velocity = transform.TransformDirection (Vector3.forward * 10);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			Destroy (gameObject);
		}
	}
}
