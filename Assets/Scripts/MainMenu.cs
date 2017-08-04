using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	public string loadLevel;
	public string levelSelect;	
	public int playerLives;
	public int playerHealth;


	public void loadDesiredLevel(){
		PlayerPrefs.SetInt ("playerCurrentLive", playerLives);
		PlayerPrefs.SetInt ("playerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("playerMaxHealth", playerHealth);
		PlayerPrefs.SetInt ("Score", 0);

		SceneManager.LoadScene (loadLevel);
	}

	public void selectLevel(){
		PlayerPrefs.SetInt ("playerCurrentLive", playerLives);
		PlayerPrefs.SetInt ("playerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("playerMaxHealth", playerHealth);
		PlayerPrefs.SetInt ("Score", 0);

		SceneManager.LoadScene (levelSelect);

	}

	public void Quit(){
		Application.Quit();
	}
}
