using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class handPosition : MonoBehaviour {

	public Camera mainCamera;
	public GameObject cube;
	public float distance;
	public float currHeight;
	public int hands;
	public float startHeight;
	public static float height;
	public bool bossLiving = true;
	public bool canMove = true;


	// Use this for initialization
	void Start () {
		startHeight = transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameScript.height >= 300 && GameScript.BossAlive == true) {
			canMove = false;
		} else {
			canMove = true;
		}


		currHeight = transform.position.y;
		height = (currHeight*10 - startHeight*10);
		hands = HandController.handsOnScreen;
		distance = cube.transform.position.y - transform.position.y;
		//transform.position = new Vector3 (transform.position.x, transform.position.z, transform.position.z);
		if(GameScript.state == "Keep_it_up") {
			if (canMove) {
				if ((distance > 5f && cube.transform.position.y > transform.position.y) || (cube.GetComponent<Rigidbody> ().velocity.y > 0)) {
					transform.Translate ((Vector3.up * Time.deltaTime) * 2.5f, cube.transform);
				}
			}
		}
			
	}
}
