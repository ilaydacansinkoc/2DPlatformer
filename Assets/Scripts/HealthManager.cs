using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {


	//public int maxPlayerHealth;
	public bool isDead;
	public static int playerHealth;
	public int maxPlayerHealth;
	//Text text;
	public Slider slider;
	private LevelManager levelManager;
	private PlayerController player;

	//public int playerLives;
	private LifeManager lifeManager;
	private TimeManager timeManager;


	// Use this for initialization
	void Start () {
		//text = GetComponent<Text> ();
		slider =GetComponent<Slider>();

		//playerHealth = maxPlayerHealth;
		playerHealth = PlayerPrefs.GetInt("playerCurrentHealth");
		levelManager = FindObjectOfType<LevelManager> ();

		isDead = false;

		player = FindObjectOfType<PlayerController> ();

		lifeManager = FindObjectOfType<LifeManager> ();
		timeManager = FindObjectOfType<TimeManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		

		if (playerHealth <= 0 && !isDead) {

			playerHealth = 0;
			lifeManager.lostLife ();
			levelManager.RespawnPlayer ();
			isDead = true;
			timeManager.ResetTime ();

		}
		if (playerHealth >= maxPlayerHealth)
			playerHealth = maxPlayerHealth;

		if (isDead) {
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
		//text.text = "" + playerHealth;
		slider.value = playerHealth;
	}

	public static void HurtPlayer(int damage){
		playerHealth -= damage;
		PlayerPrefs.SetInt("playerCurrentHealth",playerHealth);
	}

	public void FullHealth(){
		playerHealth = PlayerPrefs.GetInt ("playerMaxHealth");
		PlayerPrefs.SetInt("playerCurrentHealth",playerHealth);


	}

	public void KillPlayer(){
		playerHealth = 0;
	}

}
