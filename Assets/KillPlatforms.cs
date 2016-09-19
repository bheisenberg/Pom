using UnityEngine;
using System.Collections;

public class KillPlatforms : MonoBehaviour {

	public GameObject hand;
	public Transform[] children;
	public float handY;

	// Use this for initialization
	void Start () {
		children = GetComponentsInChildren<Transform> ();
		Debug.Log (children.Length);
	}
	
	// Update is called once per frame
	void Update () {
		handY = hand.transform.position.y+1f;
		/*for (int i = 0; i < children.Length; i++) {
			if(hand.transform.position.y > children[i].position.y) {
				children [i].GetComponent<Rigidbody> ().isKinematic = false;
			}
		}*/
		foreach (Transform child in transform) {
			if (handY > child.transform.position.y) {
				child.GetComponent<Rigidbody> ().isKinematic = false;
				if (child.GetComponent<enemyScript> () != null) {
					child.GetComponent<enemyScript> ().enabled = false;
				}
			}
		}
	}
}
