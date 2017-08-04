using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	private LifeManager lifeManager;
	private PlayerController player;
	public float waitingTime;
	public string level;
	public GameObject gameOverScreen;

	// Use this for initialization
	void Start () { 
		lifeManager = FindObjectOfType<LifeManager> ();
		player = FindObjectOfType<PlayerController> ();
	}

	
	// Update is called once per frame
	void Update () {
		

	}

	public void loadGameOverScreen(){
		gameOverScreen.SetActive (true);
		Debug.Log ("Game over screen active.");
		player.gameObject.SetActive (false);



		if (gameOverScreen.activeSelf ) {
			waitingTime -= Time.deltaTime;
		}

		if(waitingTime < 0)
			SceneManager.LoadScene (level);
	}
}
