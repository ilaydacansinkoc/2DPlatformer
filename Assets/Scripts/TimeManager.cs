using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float time;
	private float countingTime;

	private Text text;

	//public GameObject gameOverScreen;
	//private PlayerController player;
	private PauseMenu pauseMenu;
	private HealthManager healthManager;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();	
		pauseMenu = FindObjectOfType<PauseMenu> ();
		healthManager = FindObjectOfType<HealthManager> ();
		//player = FindObjectOfType<PlayerController> ();

		countingTime = time;
	}
	
	// Update is called once per frame
	void Update () {

		if (pauseMenu.isResumed)
			return;

		
		countingTime -= Time.deltaTime;

		if (countingTime <= 0) {
			//gameOverScreen.SetActive (true);
			//player.gameObject.SetActive (false);
			Debug.Log("I'm here");
			healthManager.KillPlayer();

		}
		text.text = "" + Mathf.Round(countingTime);
	}

	public void ResetTime(){
		countingTime = time;
	}
}
