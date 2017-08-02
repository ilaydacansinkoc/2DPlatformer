using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint;
	private PlayerController player;

	public int pointsForPenalty;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public CameraController controller;
	public float respawnTime;

	public HealthManager healthManager;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();		
		controller = FindObjectOfType<CameraController> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticle,player.transform.position,player.transform.rotation);
		Debug.Log ("Player Respawn");

		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		controller.isKilled = true;

		//player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		//player.GetComponent<Rigidbody2D> ().gravityScale = 0f;

		ScoreManager.AddPoints (-pointsForPenalty);
		yield return new WaitForSeconds (respawnTime);

		player.transform.position = currentCheckPoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
		controller.isKilled = false;
		player.knockbackLenght = 0;

		healthManager.FullHealth ();
		healthManager.isDead = false;
		//player.GetComponent<Rigidbody2D> ().gravityScale = 5f;
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}
}
