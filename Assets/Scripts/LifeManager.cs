using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LifeManager : MonoBehaviour {

	public int totalLife;

	private Text text;

	public GameObject gameOverScreen;

	private PlayerController player;

	public float waitingTime;

	public string level;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		totalLife = PlayerPrefs.GetInt ("playerCurrentLive");
		Debug.Log (totalLife);
		player = FindObjectOfType<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (totalLife <= 0) {
			
			gameOverScreen.SetActive (true);
			Debug.Log ("Game over screen active.");
			player.gameObject.SetActive (false);
		}

		if (gameOverScreen.activeSelf ) {
			waitingTime -= Time.deltaTime;
		}

		if(waitingTime < 0)
			SceneManager.LoadScene (level);
	

		text.text = "x " + totalLife;
	}

	public void gainLife(){

		totalLife++;
		PlayerPrefs.SetInt ("playerCurrentLive", totalLife);

	}

	public void lostLife(){
		totalLife--;
		PlayerPrefs.SetInt ("playerCurrentLive", totalLife);

	}
}
