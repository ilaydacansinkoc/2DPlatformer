﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parallaxScales;
	public float smooting;
	private Transform cam;
	private Vector3 previousCamPos;

	// Use this for initialization
	void Start () {

		cam = Camera.main.transform;
		previousCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales [i] = backgrounds [i].transform.position.z * -1;

		}
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		for (int i = 0; i < backgrounds.Length; i++) {


			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales [i];

			float backgroundTargetPosX = backgrounds [i].position.x + parallax;
			//Debug.Log (backgrounds [i].position.x);
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds [i].position.y,
				                               backgrounds [i].position.z);
			
			backgrounds [i].position = Vector3.Lerp (backgrounds[i].position,backgroundTargetPos,smooting*Time.deltaTime);
		}

		previousCamPos = cam.position;
		
	}
}
