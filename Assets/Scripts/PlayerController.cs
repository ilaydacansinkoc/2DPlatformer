﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movSpeed;
	public float jumpHeight;
	public float groundCheckRadius;

	public Transform groundCheck;
	public LayerMask whatisGround;
	private bool grounded;
	private bool doubleJumped;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate(){
		//Physics stuff.
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatisGround);

	}
	// Update is called once per frame
	void Update () {

		if (grounded)
			doubleJumped = false;

		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
			Jump();

		}

		if (Input.GetKeyDown (KeyCode.Space) && !grounded && !doubleJumped) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
			Jump();
			doubleJumped = true;

		}

		if(Input.GetKey(KeyCode.D)){
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (movSpeed, GetComponent<Rigidbody2D> ().velocity.y);

		}

		if(Input.GetKey(KeyCode.A)){
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-movSpeed,GetComponent<Rigidbody2D> ().velocity.y);

		}
	}

	public void Jump(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
	}
}