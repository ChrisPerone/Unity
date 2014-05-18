using UnityEngine;
using System.Collections;

public class ScreenWrapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 screenPt = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 destPt;
		if (screenPt.x > Screen.width) {
			destPt = Camera.main.ScreenToWorldPoint(new Vector3 (0f, 0f, 0f));
			transform.position = new Vector3(destPt.x, transform.position.y, transform.position.z);
		} else if (screenPt.x < 0) {
			destPt = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, 0f, 0f));
			transform.position = new Vector3(destPt.x, transform.position.y, transform.position.z);
		}
		if (screenPt.y > Screen.height) {
			destPt = Camera.main.ScreenToWorldPoint(new Vector3 (0f, 0f, 0f));
			transform.position = new Vector3(transform.position.x, destPt.y, transform.position.z);
		} else if (screenPt.y < 0) {
			destPt = Camera.main.ScreenToWorldPoint(new Vector3 (0f, Screen.height, 0f));
			transform.position = new Vector3(transform.position.x, destPt.y, transform.position.z);
		}	
	}
}
