using UnityEngine;
using System.Collections;

public class BGScript : MonoBehaviour {

	public Transform[] clouds;
	public Camera mainCamera;
	public GameObject hand;
	public GameObject moon;

	// Use this for initialization
	void Start () {
		clouds = GetComponentsInChildren<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {


		float bottom = mainCamera.transform.position.y-7;
		float top = mainCamera.transform.position.y+7;

		if (GameScript.height > 310) {
			if (GameObject.FindGameObjectsWithTag ("moon").Length == 0) {
				GameObject newMoon = Instantiate (moon, new Vector3 (mainCamera.transform.position.x, mainCamera.transform.position.y + 10, -2.2f), transform.rotation) as GameObject;
			}
		}

		foreach(Transform child in transform) {
			if (child.transform.position.y <= bottom && GameScript.height <= 310) {
				child.transform.position += new Vector3 (0, 15f, 0);
				Debug.Log ("moved a cloud");
			}
			if (GameScript.height > 310) {
				clouds [1].GetComponent<Rigidbody> ().isKinematic = false;
				clouds [2].GetComponent<Rigidbody> ().isKinematic = false;
				clouds [3].GetComponent<Rigidbody> ().isKinematic = false;
			} else {
				clouds [1].GetComponent<Rigidbody> ().isKinematic = true;
				clouds [2].GetComponent<Rigidbody> ().isKinematic = true;
				clouds [3].GetComponent<Rigidbody> ().isKinematic = true;	
			}
			if (child.transform.position.x > -5 && child.transform.position.x < 5) {
				clouds [1].transform.position += new Vector3 (0.04f, 0, 0);
				clouds [2].transform.position += new Vector3 (0.01f, 0, 0);
				clouds [3].transform.position += new Vector3 (0.02f, 0, 0);
			} else {
				child.transform.position -= new Vector3 (10, 0, 0);
			}
		}
	}
}
