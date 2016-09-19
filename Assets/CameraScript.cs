using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject cube;
	public GameObject hand;
	public GameObject fade;
	public GameObject walls;
	public float cubeHeight;
	public float handHeight;
	public float avgHeight;
	public float endTimer = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cubeHeight = cube.transform.position.y;
		handHeight = hand.transform.position.y;
		avgHeight = (cubeHeight + handHeight) / 2;
		fade.transform.position = new Vector3 (hand.transform.position.x, hand.transform.position.y-1f, hand.transform.position.z);
		walls.transform.position = new Vector3 (walls.transform.position.x, hand.transform.position.y-50f, walls.transform.position.z);

		if (cubeHeight >= handHeight) {
			transform.position = new Vector3 (0, handHeight+5, -20);
		} else {
			transform.position = new Vector3 (0, cubeHeight, -20);
			Invoke ("End", 1f);
		}
	}

	void End () {
		cube.GetComponent<Rigidbody> ().isKinematic = true;
		GameScript.endGame ();
	}
}
