using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint;
	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnTime;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();		
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
		yield return new WaitForSeconds (respawnTime);
		player.transform.position = currentCheckPoint.transform.position;
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}
}
