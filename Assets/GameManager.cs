using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject GameOverPanel;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		GameOverPanel.gameObject.SetActive (false);
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
		Time.timeScale = 0;
		GameOverPanel.gameObject.SetActive (true);
	}

	public void RestartGame() {
		SceneManager.LoadScene("firstscene");
		Time.timeScale = 1;
	}
}
