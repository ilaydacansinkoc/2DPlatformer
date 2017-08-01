using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;
	public bool isDead;
	public static int playerHealth;
	Text text;
	private LevelManager levelManager;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();

		playerHealth = maxPlayerHealth;

		levelManager = FindObjectOfType<LevelManager> ();

		isDead = false;

		player = FindObjectOfType<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (playerHealth <= 0 && !isDead) {

			playerHealth = 0;
			levelManager.RespawnPlayer ();
			isDead = true;
		}

		if (isDead) {
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
		text.text = "" + playerHealth;
	}

	public static void HurtPlayer(int damage){
		playerHealth -= damage;
	}

	public void FullHealth(){
		playerHealth = maxPlayerHealth;
	}

}
