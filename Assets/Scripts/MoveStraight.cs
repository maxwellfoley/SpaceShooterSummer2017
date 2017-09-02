using UnityEngine;
using System.Collections;

public class MoveStraight : MonoBehaviour {

	public Vector2 direction; 
	public float speed; 
	bool paused;

	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!paused) {
			transform.Translate (new Vector3 (direction.x * speed, direction.y * speed, 0));
		}
	}

	void PauseMovement () {
		paused = true;
	}

	void UnpauseMovement () {
		paused = false;
	}

}
