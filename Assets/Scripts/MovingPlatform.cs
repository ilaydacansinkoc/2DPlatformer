using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float movingSpeed;
	public int index;

	public GameObject platform;
	private Transform currentPoint;
	public Transform[] transforms;


	// Use this for initialization
	void Start () {
				
		currentPoint = transforms [index];


	}
	
	// Update is called once per frame
	void Update () {
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.transform.position, movingSpeed * Time.deltaTime);

		if (platform.transform.position == currentPoint.transform.position) {
			index++;

			if (index == transforms.Length)
				index = 0;
		}

		currentPoint = transforms [index];


	}
}
