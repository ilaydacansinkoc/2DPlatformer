using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	public bool isKilled;

	public float xOffset;
	public float yOffset;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		isKilled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!isKilled)
			transform.position = new Vector3 (player.transform.position.x + xOffset,
				player.transform.position.y + yOffset,transform.position.z);
		
		
	}
}
