using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpAndShoot : MonoBehaviour {

	public Vector2 speed;

	enum State {Searching, Reloading, Firing};
	State curState;
	int counter;
	int counterBuf;
	float horizontalDistanceFromPlayerToShootAt = .05;
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
			// move towards player
			float horizontalMovement;
			if (player.transform.position.x < transform.position.x) {
				horizontalMovement = -1 * speed.x;
			} else {
				horizontalMovement = speed.x;
			}

			transform.Translate (new Vector3 (horizontalMovement, speed.y, 0.0));

			//if lined up, switch to firing state 
			if (Mathf.Abs (player.transform.position.x - transform.position.x)
			    < horizontalDistanceFromPlayerToShootAt) {
				curState = State.Reloading; 
				counterBuf = counter;
			}
		} else if (curState == State.Reloading) {
			//basically just wait for half a second 
			if (counter > counterBuf + waitTimeBeforeShoot) {
				curState = State.Firing;
				counterBuf = counter;
			}
		}
		else if (curState == State.Reloading) {

			int timeElapsed = counter - counterBuf; 

			//shoot at regular intervals
			if (timeElapsed % timeInBetweenBullets == 0) {
				GameObject myBullet = Instantiate (bullet, transform.position, transform.rotation);
				myBullet.GetComponent<MoveStraight>().direction = new Vector2 (0, 1);
				myBullet.GetComponent<MoveStraight>().speed = 0.05f;

			}

			//go back to searching after a specified time 
			if (timeElapsed > timeShootingLasts) {
				curState = State.Searching;
				counterBuf = counter;
			}
		}
	}
}
