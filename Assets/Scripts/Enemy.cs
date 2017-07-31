using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public float wallCheckRadius;
	public Transform wallCheck;
	public LayerMask whatisWall;
	private bool touchedWall;

	public bool notAtEdge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		touchedWall = Physics2D.OverlapCircle(wallCheck.position,wallCheckRadius,whatisWall);
		notAtEdge = Physics2D.OverlapCircle(edgeCheck.position,wallCheckRadius,whatisWall);
	
			
		if (touchedWall || !notAtEdge)
			moveRight = !moveRight;
		
		if (moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
