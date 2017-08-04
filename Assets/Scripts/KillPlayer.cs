using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;
	//private PlayerController player;
	private LifeManager lifeManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		lifeManager = FindObjectOfType<LifeManager> ();
		//player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "Player") {
			lifeManager.lostLife ();
			levelManager.RespawnPlayer ();


		}
	}
}
