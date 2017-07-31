using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour {

	public float movSpeed;
	public PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x < 0)
			movSpeed = -movSpeed;
		
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (movSpeed, GetComponent<Rigidbody2D> ().velocity.y);


		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Enemy")
			Destroy (other.gameObject);
		
		Destroy (gameObject);
	}
}
