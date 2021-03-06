﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector2 speed;
	//Vector3 speed3;
	public GameObject bullet;
	public int maxHealth;
	int health;
	int score;
	GameObject GameArea;
	BoxCollider GameAreaCollider; 
	Text HealthText;
	Text ScoreText;
	float halfWidth;
	float halfHeight;


	// Use this for initialization
	void Start () {
		GameArea = GameObject.Find ("GameArea"); 
		HealthText = GameObject.Find ("HealthText").GetComponent<Text>();
		ScoreText = GameObject.Find ("ScoreText").GetComponent<Text>(); 
		GameAreaCollider = GameArea.GetComponent<BoxCollider>(); 

		//half the width and height of the player's bounding box
		halfWidth = GetComponent<BoxCollider>().bounds.extents.x;
		halfHeight = GetComponent<BoxCollider>().bounds.extents.y;

		this.setHealth(maxHealth);
	//	speed3 = new Vector3 (speed.x, speed.y, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveHorizontal != 0 || moveVertical != 0) {
			
			Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

			//calculate desired position
			Vector3 currentPosition = transform.position;
			Vector3 speedMovement = new Vector3 (movement.x * speed.x, movement.y * speed.y, 0.0f);
			Vector3 futurePosition = currentPosition + speedMovement; 

			//clamp position to game bounds
			transform.position = new Vector3 (Mathf.Clamp (futurePosition.x, GameAreaCollider.bounds.min.x + halfWidth, GameAreaCollider.bounds.max.x - halfWidth),
				                          Mathf.Clamp (futurePosition.y, GameAreaCollider.bounds.min.y + halfHeight, GameAreaCollider.bounds.max.y - halfHeight), 0.0f);


			if (health <= 0) {
				//Object.Destroy (this.gameObject);
				GameObject.Find("Master").GetComponent<GameManager>().GameOver();
			}
		}

		if (Input.GetKeyDown ("space")) {

			GameObject myBullet = Instantiate (bullet, transform.position, transform.rotation);
			myBullet.GetComponent<MoveStraight>().direction = new Vector2 (0, 1);
			myBullet.GetComponent<MoveStraight>().speed = 0.05f;
		}

	}

	public int getHealth() {
		return health;
	}

	public void setHealth(int i){
		health = i;
		HealthText.text = "health " + i.ToString();
	}

	public int getScore() {
		return score;
	}

	public void setScore(int i) {
		score = i;
		ScoreText.text = "score " + i.ToString(); 
	}
}
