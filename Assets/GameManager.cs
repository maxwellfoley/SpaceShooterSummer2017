using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject GameOverPanel;

	// Use this for initialization
	void Start () {
		GameOverPanel.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameOver() {
		GameOverPanel.gameObject.SetActive (true);

	}
}
