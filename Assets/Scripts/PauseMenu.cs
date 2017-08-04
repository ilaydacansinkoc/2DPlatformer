using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string loadLevel;
	public string levelLoader;

	public GameObject canvas;
	public bool isResumed;

	void Start(){
		isResumed = false;
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isResumed = !isResumed;
		}


		if (isResumed) {
			
			canvas.SetActive (true);
			Time.timeScale = 0f;

		} else {
			canvas.SetActive (false);
			Time.timeScale = 1f;
		}




	}


	public void Resume(){

		isResumed = false;
		Debug.Log ("Resumed");
		
	}
	public void selectLevel(){
		SceneManager.LoadScene (levelLoader);
	}
	public void ReturnMenu(){
		SceneManager.LoadScene (loadLevel);
	}
}
