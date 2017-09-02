using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInBursts : MonoBehaviour {

	int counter;
	int counterBuf;
	public GameObject bullet;
	public int timeBetweenBursts;
	public int burstLength;
	public int timeBetweenShots;


	enum State {Reloading, Firing};
	State curState;


	// Use this for initialization
	void Start () {
		//make it start sometime random so these enemies aren't all in sync when they shoot 
		counter = (int)(Random.value*timeBetweenBursts);
		counterBuf = counter;
		curState = State.Reloading; 
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		//wait until time passes to fire
		if (curState == State.Reloading) {
			if (counter > counterBuf + timeBetweenBursts) {
				curState = State.Firing; 
				this.SendMessage ("PauseMovement");
				counterBuf = counter; 
			}
		} 
		else if (curState == State.Firing) {
			//fire at regular intervals
			int timeElapsed = counter - counterBuf;
			if (timeElapsed % timeBetweenShots == 0) {
				GameObject myBullet = Instantiate (bullet, this.transform.position + new Vector3(.001f,0.0f,0.0f), transform.rotation);
			}
			//if we're past the length of time to fire, go back to reloading 
			if (timeElapsed > burstLength) {
				this.SendMessage ("UnpauseMovement");
				curState = State.Reloading; 
				counterBuf = counter; 
			}
		}
	}
}
