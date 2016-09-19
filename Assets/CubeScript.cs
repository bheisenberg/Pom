using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CubeScript : MonoBehaviour {

	float startTimer = 3;
	public GameObject hand;
	public float currentVelocity;
	public static bool gameStart = false;
	public static float hits = 0;


	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody> ().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {

		currentVelocity = this.GetComponent<Rigidbody> ().velocity.y;


	}


	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "hand") {
			Debug.Log ("hit");
			this.GetComponent<Rigidbody> ().AddForce (0, 20f, 0);
			hits += 0.5f;
		}
		if (collision.gameObject.tag == "Untagged") {
			GameScript.endGame ();
			this.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
}
