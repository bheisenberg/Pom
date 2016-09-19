using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	public int hands;
	public static string state;
	public string localState;
	public string prevState;
	public Text intro;
	public Text heightText;
	public Text countDown;
	public Text counter;
	public int hits;
	public float startTimer = 3;
	public GameObject cube;
	public static float height;
	int count = 0;
	public bool textKilled = false;
	public int displayTimer;
	public bool countingDown;
	public static bool BossAlive = true;
	public Text bossHealthText;
	public int bossHealth;
	public GameObject boss;
	public Text title;
	bool removingTitle;
	private Vector3 titleOrig;
	public Text high;
	public Animator anim;
	public Text credits;
	private Vector3 scoreOrig;

	void Awake () {
		hands = HandController.handsOnScreen;
	}

	// Use this for initialization
	void Start () {
		state = "intro";
		countDown.text = "";
		counter.text = "";
		titleOrig = title.transform.position;
		scoreOrig = heightText.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		bossHealth = BossScript.health;

		hits = (int)CubeScript.hits;
		hands = HandController.handsOnScreen;
		height = handPosition.height/2;
		displayTimer = (int)startTimer + 1;
		localState = state;

		if ((int)height > PlayerPrefs.GetInt ("Score")) {
			anim.SetBool ("highscore", true);

		} else {
			anim.SetBool ("highscore", false);
		}

		heightText.text = +(int)height + "ft";




		high.text = "Best: " + PlayerPrefs.GetInt ("Score") + "ft";

		if(Input.GetKeyDown(KeyCode.Delete)) {
			PlayerPrefs.DeleteAll();
		}


		if (removingTitle) {
			if (title.transform.position.x < titleOrig.x + 1000) {
				title.rectTransform.position += new Vector3 (10f, 0, 0);
				high.rectTransform.position += new Vector3 (10f, 0, 0);
				credits.rectTransform.position += new Vector3 (10f, 0, 0);
				Debug.Log ("movin");
			}
		}
		

		if (BossAlive && GameObject.FindGameObjectsWithTag("boss").Length == 1) {
			bossHealthText.text = "Health: " + bossHealth / 2;
		} else {
			bossHealthText.text = "";
		}

		if (height >= 300 && GameObject.FindGameObjectsWithTag("boss").Length == 0) {
			Instantiate (boss);
		}

		if (height >= 300) {
			if (!textKilled) {
				intro.text = "Flick your wrist!";
			}
			Invoke("KillText", 1f);
		}

		//Countdowns

		if ((state == "intro" || state == "No_hand") && hands == 1 && startTimer > 0 && !countingDown) {
			StartCountDown ();
			Invoke ("RemoveTitle", 2f);
		}

		if (countingDown == true && startTimer > 0) {
			startTimer -= Time.deltaTime;
			countDown.text = "" + displayTimer;
		}

		if (countingDown == true && startTimer <= 0) {
			FinishCountDown ();
			countingDown = false;
		}

		if (state == "End") {
			intro.text = "Move your hand away from the LEAP motion controller to try again";
			heightText.text = "Score: " + (int)height + "ft";
			if (heightText.transform.position.y < scoreOrig.y + 1000) {

				heightText.rectTransform.position += new Vector3 (0, 10f, 0);
				high.rectTransform.position += new Vector3 (-10f, 0, 0);
				Debug.Log ("movin");
			}
		}
			
		if (state == "End" && hands == 0) {
			Invoke ("RestartScene", 1f);
		}

		//Error handling

		if (hands == 0 && (state == "Keep_it_up" || state == "Bounce" || state == "Boss_fight")) {

			cube.GetComponent<Rigidbody> ().isKinematic = true;
			Debug.Log ("lost hand");
			prevState = state;
			state = "No_hand";
		}

		if (state == "Keep_it_up") {
		}
			





	}


	public static void endGame () {
		//intro.text = +height + " ft \n Try again?";

		if (height > PlayerPrefs.GetInt ("Score")) {
			PlayerPrefs.SetInt ("Score", (int)height);
		}
		Debug.Log ("Score: " +PlayerPrefs.GetInt("Score")+ " ft");
		state = "End";

			
	}

	public void StartCountDown () {
		cube.GetComponent<Rigidbody> ().isKinematic = true;
		countingDown = true;
		intro.text = "";
	}

	public void StartKeepItUp() {
		state = "Keep_it_up";
		Invoke ("KillText", 1f);
	}

	public void FinishCountDown () {
		startTimer = 3;
		countingDown = false;
		cube.GetComponent<Rigidbody> ().isKinematic = false;
		intro.text = "";
		countDown.fontSize = 64;
		if (state == "intro") {
			countDown.text = "Keep it up!";
			StartKeepItUp();
		}
		else if (state == "No_hand") {
			countDown.text = "Resume!";
			state = prevState;
			KillText ();
		}

	}


	void KillText() {
		countDown.text = "";
		intro.text = "";
		counter.text = "";
		textKilled = true;
	}

	void RemoveTitle() {
		removingTitle = true;
	}

	void RestartScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
		
}
