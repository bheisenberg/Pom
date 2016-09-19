using UnityEngine;
using System.Collections;

public class moonScript : MonoBehaviour {

	Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > mainCamera.transform.position.y + 4) {
			transform.position -= new Vector3 (0.1f, 0, 0);
		} else {
			transform.position = new Vector3 (mainCamera.transform.position.x, mainCamera.transform.position.y + 4, transform.position.z);
		}
	}
}
