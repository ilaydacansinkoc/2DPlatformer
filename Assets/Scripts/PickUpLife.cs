using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife : MonoBehaviour {

	private LifeManager lifeManager;
	// Use this for initialization
	void Start () {
		lifeManager = FindObjectOfType<LifeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			lifeManager.gainLife ();
			Destroy (gameObject);
		}
	}
}
