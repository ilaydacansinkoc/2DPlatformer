using System.Collections;
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

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
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

		}

		if (Input.GetKeyDown (KeyCode.Space) && !grounded && !doubleJumped) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
			Jump();
			doubleJumped = true;

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

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelociy, GetComponent<Rigidbody2D> ().velocity.y);


		anim.SetFloat ("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}

	public void Jump(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
	}
}
