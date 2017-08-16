using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainLife : MonoBehaviour {

	public int gainLife;
	public AudioSource pickEffect;

	void Start(){
		pickEffect = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<PlayerController> () == null)
			return;
		
		HealthManager.HurtPlayer (-gainLife);
		pickEffect.Play ();
		Destroy (gameObject);
	}
}
