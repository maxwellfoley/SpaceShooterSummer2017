using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLevel : MonoBehaviour {

	int counter;
	int counterBuf;
	public int pauseTime;
	bool hasEntered;
	LevelManager lm;

	// Use this for initialization
	void Start () {
		counter = 0;
		counterBuf = 0;
		hasEntered = false; 
		lm = GameObject.Find ("Level").GetComponent<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		counter++;

		if (hasEntered && counter > counterBuf + pauseTime) {
			hasEntered = false;
			lm.UnpauseLevel ();
		}
	}

	public void OnEnter() {
		hasEntered = true;
		counterBuf = counter;
		lm.PauseLevel ();
	}
}
