using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			HealthManager.HurtPlayer (damageToGive);
			col.GetComponent<AudioSource> ().Play();

			var player = col.GetComponent<PlayerController> ();
			player.knockbackCount = player.knockbackLenght;

			if (col.transform.position.x < transform.position.x)
				player.knockbackFromRight = true;
			else {
				player.knockbackFromRight = false;
			}
		}


	}
}
