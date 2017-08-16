using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

	public float movSpeed;
	public float playerRange;
	public LayerMask mask;
	public PlayerController player;

	public bool playerInRange;
	public bool isFacingAway;
	public bool followOnLookAway;



	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange,mask);
		if (!followOnLookAway) {
			if (playerInRange) {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, movSpeed * Time.deltaTime);
				return;
			}
		}

		if ((player.transform.position.x < transform.position.x && player.transform.localScale.x < 0) || (player.transform.position.x > transform.position.x && player.transform.localScale.x > 0)) {

			isFacingAway = true;
		} else {
			isFacingAway = false;
		}
		if (isFacingAway && playerInRange) {

			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, movSpeed * Time.deltaTime);

		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawSphere (transform.position, playerRange);
	}
}
