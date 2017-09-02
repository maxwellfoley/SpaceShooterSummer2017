using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float speed;
	public bool paused; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!paused) {
			transform.Translate (0.0f, speed, 0.0f);
		}
	}

	public void PauseLevel() {
		paused = true;
	}

	public void UnpauseLevel() {
		paused = false;

	}
}
