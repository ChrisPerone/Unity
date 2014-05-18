using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public float speed = 8.0f;
	public float lifespan = 1.0f;
	private Vector3 eulerRot;
	private float expireTime;

	// Use this for initialization
	void Start () {
		eulerRot = transform.rotation.eulerAngles;
		expireTime = Time.time + lifespan;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time >= expireTime)
			Destroy (gameObject);
		else
			rigidbody2D.velocity = new Vector2 (speed * Mathf.Cos(eulerRot.z * Mathf.Deg2Rad), speed * Mathf.Sin(eulerRot.z * Mathf.Deg2Rad));
	}
}
