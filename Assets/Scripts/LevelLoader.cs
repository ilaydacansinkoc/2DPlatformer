using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public bool isInZone;
	public string levelName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isInZone && Input.GetAxisRaw("Vertical")>0)
			SceneManager.LoadScene (levelName);
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player")
			isInZone = true;
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player")
			isInZone = false;
	}
}
