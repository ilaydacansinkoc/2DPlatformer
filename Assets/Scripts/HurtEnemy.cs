using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;

	public float bouncePlayer;
	 
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "Enemy") {
			col.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
			rb2d.velocity = new Vector2 (rb2d.velocity.x, bouncePlayer);

		}
	}
}
