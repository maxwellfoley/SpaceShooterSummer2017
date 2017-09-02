using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeUniversalObjects : MonoBehaviour {

	public GameObject Player;
	public Vector2 playerPosition;

	public GameObject Camera;
	public GameObject GameHUD; 
	public GameObject GameArea; 

	// Use this for initialization
	void Awake () {

		GameObject myPlayer = Instantiate (Player, new Vector3 (playerPosition.x, playerPosition.y, 0.0f), Quaternion.identity);
		myPlayer.name = "Player"; //do this so there's no (Clone) bullshit

		GameObject myCamera = Instantiate (Camera, new Vector3 (0.0f, 0.0f, 10.0f), Quaternion.identity);
		myCamera.name = "MainCamera"; //do this so there's no (Clone) bullshit

		GameObject _GameHUD = Instantiate (GameHUD, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		_GameHUD.name = "GameHUD";

		GameObject _GameArea = Instantiate (GameArea, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		_GameArea.name = "GameArea";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
