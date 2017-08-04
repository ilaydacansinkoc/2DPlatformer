using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Transform groundCheck;
	public LayerMask whatisGround;
	private Animator anim;
	public Transform ninjaSpawn;
	public GameObject ninjaStar;
	private AudioSource jumpEffect;

	public float shotDelay;
	public float shotDelayCounter;
	public float knockback;
	public float knockbackLenght ;
	public float knockbackCount;
	public float movSpeed;
	public float jumpHeight;
	private float moveVelociy;
	public float groundCheckRadius;

	public float climbSpeed;
	public float climbVelocity;
	private float gravityStore;

	public bool knockbackFromRight;
	public bool onLadder;
	private bool grounded;
	private bool doubleJumped;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		jumpEffect = GetComponentInChildren<AudioSource> ();
		gravityStore = GetComponent<Rigidbody2D> ().gravityScale;
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

		if(Input.GetButtonDown("Jump") && grounded){
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
			Jump();
			jumpEffect.Play ();

		}

		if (Input.GetButtonDown("Jump") && !grounded && !doubleJumped) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
			Jump();
			doubleJumped = true;
			jumpEffect.Play ();

		}

		moveVelociy = Input.GetAxisRaw ("Horizontal")* movSpeed;

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

		if (Input.GetButtonDown ("Fire1")) {
			Instantiate (ninjaStar, ninjaSpawn.position,ninjaSpawn.rotation);
			shotDelayCounter = shotDelay;
		}

		if (Input.GetButton ("Fire1")) {
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate (ninjaStar, ninjaSpawn.position,ninjaSpawn.rotation);

			}

		}

		if (anim.GetBool ("Sword")) 
			anim.SetBool ("Sword", false);
		
		if (Input.GetButton("Fire2")) 
			anim.SetBool ("Sword", true);
		

		if (onLadder) {
			GetComponent<Rigidbody2D> ().gravityScale = 0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, climbVelocity);
				
		}

		if (!onLadder) {
			GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		}
	}

	public void Jump(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,jumpHeight);
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.transform.tag == "Platform") {
			Debug.Log ("Collided");
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.transform.tag == "Platform") {
			Debug.Log ("Collided");
			transform.parent = null;
		}
	}
}
