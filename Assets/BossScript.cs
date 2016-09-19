using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossScript : MonoBehaviour {

	// Use this for initialization
	public Vector3 pointB;
	public Vector3 distanceToMove;
	public float rate = 2.0f;
	public static int health = 10;




	IEnumerator Start()
	{
		var pointA = transform.position;
		pointB = new Vector3(pointA.x + distanceToMove.x, pointA.y + distanceToMove.y, pointA.z + distanceToMove.z);
		while(true && health > 0)
		{
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate_ = rate/time;
		while(i < 1.0f)
		{
			i += Time.deltaTime * rate_;
			if (health > 0) {
				thisTransform.position = Vector3.Lerp (startPos, endPos, i);
			}
			yield return null;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
				transform.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 0, 0);
				this.GetComponent<Rigidbody> ().detectCollisions = false;
				Invoke ("FixColor", 0.2f);
				Invoke ("FixColl", 1f);
				health -= 1;
				Debug.Log ("hit");

		}
	}




	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.I)) {
			health -= 2;
		}

		if (health <= 0) {
			this.GetComponent<Rigidbody> ().isKinematic = false;
			this.GetComponent<Rigidbody> ().detectCollisions = false;
			this.GetComponent<Rigidbody> ().useGravity = true;
			this.GetComponent<BoxCollider> ().enabled = false;
			GameScript.BossAlive = false;
		}
	}

	void FixColor() {
		transform.GetComponent<SpriteRenderer> ().material.color = new Color (1, 1, 1);
	}

	void FixColl () {
		this.GetComponent<Rigidbody> ().detectCollisions = true;
	}
}
