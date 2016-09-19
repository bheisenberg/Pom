using UnityEngine;
using System.Collections;

public class wallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			if (this.gameObject.tag == "left") {
				collision.gameObject.GetComponent<Rigidbody> ().AddForce (3f, 0, 0);
				Debug.Log ("left");
			} else if (this.gameObject.tag == "right") {
				collision.gameObject.GetComponent<Rigidbody> ().AddForce (-3f, 0, 0);
				Debug.Log ("Right");
			}
		}
	}
}
