using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {


	// Use this for initialization
	public Vector3 pointB;
	public Vector3 distanceToMove;
	GameObject hand;
	public float handY;

	IEnumerator Start()
	{
		var pointA = transform.position;
		pointB = new Vector3(pointA.x + distanceToMove.x, pointA.y + distanceToMove.y, pointA.z + distanceToMove.z);
		while(true)
		{
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 2.0f/time;
		while(i < 1.0f)
		{
			i += Time.deltaTime * rate;
			if (handY < transform.position.y) {
				thisTransform.position = Vector3.Lerp (startPos, endPos, i);
			}
			yield return null;
		}
	}
	// Update is called once per frame
	void Update () {
		hand = GameObject.FindGameObjectWithTag ("handpos");
		handY = hand.transform.position.y+1f;

	}
}
