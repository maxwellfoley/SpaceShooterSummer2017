using UnityEngine;
using System.Collections;

public class HorizontalMovement: MonoBehaviour {

	float startPoint; 
	public float range; 
	public float speed; 
	float direction;
	bool paused;


	// Use this for initialization
	void Start () {
		startPoint = transform.position.x; 
		direction = 1;
		paused = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!paused) {
			float xPoint = transform.position.x;

			if (xPoint < startPoint - range / 2) {
				direction = 1;
			} else if (xPoint > startPoint + range / 2) {
				direction = -1;
			}

			transform.Translate (new Vector3 (direction * speed, 0, 0));
		}
	}

	void PauseMovement () {
		paused = true;
	}

	void UnpauseMovement () {
		paused = false;
	}
}
