﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		Debug.Log("in game manager start");
		//GameOverPanel = GameObject.Find ("GameOverScreen");
		//GameOverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		//Pauses game
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
			} else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
		}

	}

	public void GameOver() {
		//GameOverPanel.SetActive (true);
		PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
		//Time.timeScale = 0;
		SceneManager.LoadScene("GameOverScreen");

	}

	public void RestartGame() {
		SceneManager.LoadScene("firstscene");
		//Time.timeScale = 1;
		//GameOverPanel = GameObject.Find ("GameOverScreen");
	}
}
