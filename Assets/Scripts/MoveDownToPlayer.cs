﻿using UnityEngine;
using System.Collections;

public class MoveDownToPlayer : MonoBehaviour {

	public float speed; 
	GameObject player; 
	bool paused;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player"); 
		paused = false;


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!paused) {
			float yPoint = transform.position.y;
			float playerYPoint = player.transform.position.y;
						
			if (yPoint - 0.25f > playerYPoint) {
				transform.Translate (new Vector3 (0, -speed, 0));
			}
		}
	}

	void PauseMovement () {
		paused = true;
	}

	void UnpauseMovement () {
		paused = false;
	}
}
