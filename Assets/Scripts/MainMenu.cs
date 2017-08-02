using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	public string loadLevel;
	public string levelSelect;

	public void loadDesiredLevel(){
		SceneManager.LoadScene (loadLevel);
	}

	public void selectLevel(){
		SceneManager.LoadScene (levelSelect);
	}

	public void Quit(){
		Application.Quit();
	}
}
