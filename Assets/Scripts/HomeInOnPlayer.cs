using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeInOnPlayer : MonoBehaviour {

	public float speed; 
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = player.transform.position - transform.position;
		direction.Normalize ();
		direction *= speed;
		transform.Translate (direction);

		
	}
}
