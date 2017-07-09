using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpAndShoot : MonoBehaviour {

	public Vector2 speed;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalMovement;
		if (player.transform.position.x < transform.position.x) {
			horizontalMovement = -1 * speed.x;
		} else {
			horizontalMovement = speed.x;
		}
	}
}
