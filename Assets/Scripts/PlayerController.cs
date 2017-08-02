﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movSpeed;
	public float jumpHeight;
	private float moveVelociy;


	public float groundCheckRadius;
	public Transform groundCheck;
	public LayerMask whatisGround;
	private bool grounded;

	private bool doubleJumped;

	private Animator anim;
	public Transform ninjaSpawn;
	public GameObject ninjaStar;

	public float shotDelay;
	public float shotDelayCounter;

	public float knockback;
	public float knockbackLenght ;
	public float knockbackCount;
	public bool knockbackFromRight;

	private AudioSource jumpEffect;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		jumpEffect = GetComponentInChildren<AudioSource> ();
	}

	void FixedUpdate(){
		//Physics stuff.
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatisGround);

	}
	// Update is called once per frame
	void Update () {

		if (grounded)
			doubleJumped = false;

		anim.SetBool ("Grounded", grounded);

		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
			Jump();
			jumpEffect.Play ();

		}

		if (Input.GetKeyDown (KeyCode.Space) && !grounded && !doubleJumped) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
			Jump();
			doubleJumped = true;
			jumpEffect.Play ();

		}

		moveVelociy = 0f;

		if(Input.GetKey(KeyCode.D)){
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (movSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelociy = movSpeed;
		}

		if(Input.GetKey(KeyCode.A)){
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (-movSpeed,GetComponent<Rigidbody2D> ().velocity.y);
			moveVelociy = -movSpeed;
		}

		if (knockbackCount <= 0)
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelociy, GetComponent<Rigidbody2D> ().velocity.y);
		else {
			if (knockbackFromRight) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback,knockback);
			}
			if (!knockbackFromRight) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback,knockback);
			}
			knockbackCount -= Time.deltaTime;

		}

		anim.SetFloat ("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Instantiate (ninjaStar, ninjaSpawn.position,ninjaSpawn.rotation);
			shotDelayCounter = shotDelay;
		}

		if (Input.GetKey (KeyCode.R)) {
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate (ninjaStar, ninjaSpawn.position,ninjaSpawn.rotation);

			}

		}

		if (anim.GetBool ("Sword")) {
			anim.SetBool ("Sword", false);
		}

		if (Input.GetKey (KeyCode.F)) {
			anim.SetBool ("Sword", true);
		}
	}

	public void Jump(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
	}
}
