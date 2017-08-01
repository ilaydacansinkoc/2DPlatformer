using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour {

	public float movSpeed;
	public PlayerController player;

	public ParticleSystem deathParticle;
	public ParticleSystem ninjaStarDeathParticle;

	public float angularVelocity;
	public int pointsForKill;

	public int damageToGive;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x < 0)
			movSpeed = -movSpeed;
		angularVelocity = -angularVelocity;
		
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (movSpeed, GetComponent<Rigidbody2D> ().velocity.y);

		GetComponent<Rigidbody2D> ().angularVelocity = angularVelocity;

		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Enemy") {

			/*Instantiate (deathParticle, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			ScoreManager.AddPoints (pointsForKill);*/

			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);

		} else {
			Instantiate (ninjaStarDeathParticle, transform.position, transform.rotation);
			Destroy (gameObject);
		}


	}
}
