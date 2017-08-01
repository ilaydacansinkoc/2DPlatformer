using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoins : MonoBehaviour {

	public int gainPoints;
	public AudioSource pickEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<PlayerController> () == null)
			return;
		ScoreManager.AddPoints (gainPoints);

		pickEffect.Play ();
		Destroy (gameObject);
	}
}
