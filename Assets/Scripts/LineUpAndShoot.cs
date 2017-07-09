using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpAndShoot : MonoBehaviour {

	public Vector2 speed;

	enum State {Searching, Reloading, Firing};
	State curState;
	int counter;
	int counterBuf;
	float horizontalDistanceFromPlayerToShootAt = .05f;
	int waitTimeBeforeShoot = 30;
	int timeInBetweenBullets = 5;
	int timeShootingLasts = 60;
	public GameObject bullet;


	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		curState = State.Searching;
		counter = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		counter++; 

		if (curState == State.Searching) {
			Debug.Log("searching");

			// move towards player
			float horizontalMovement;

			if (player.transform.position.x < transform.position.x) {
				horizontalMovement = -1 * speed.x;
			} else {
				horizontalMovement = speed.x;
			}

			transform.Translate (new Vector3 (horizontalMovement, speed.y, 0.0f));

			//if lined up, switch to firing state 
			if (Mathf.Abs (player.transform.position.x - transform.position.x)
			    < horizontalDistanceFromPlayerToShootAt) {
				curState = State.Reloading; 
				counterBuf = counter;
			}
		} else if (curState == State.Reloading) {
			Debug.Log("reloading");

			//basically just wait for half a second 
			if (counter > counterBuf + waitTimeBeforeShoot) {
				curState = State.Firing;
				counterBuf = counter;
			}
		}
		else if (curState == State.Firing) {

			int timeElapsed = counter - counterBuf; 

			Debug.Log("firing " + timeElapsed);

			//shoot at regular intervals
			if (timeElapsed % timeInBetweenBullets == 0) {
				
				GameObject myBullet = Instantiate (bullet, transform.position, transform.rotation);
			}

			//go back to searching after a specified time 
			if (timeElapsed > timeShootingLasts) {
				curState = State.Searching;
				counterBuf = counter;
			}
		}
	}
}
