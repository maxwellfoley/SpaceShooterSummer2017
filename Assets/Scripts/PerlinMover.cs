using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMover : MonoBehaviour {

	int counter; 
	float seedX;
	float seedY;

	// Use this for initialization
	void Start () {
		counter = 0;
		seedX = Random.value * 100000.0f; 
		seedY = Random.value * 100000.0f; 

	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		float moveX = Mathf.PerlinNoise ((float)counter, seedX);
		float moveY = Mathf.PerlinNoise ((float)counter, seedY);

		//map on to -.991 to .001
		moveX = ((moveX *2.0f)-1.0f)*.01f; 
		moveY = ((moveY *2.0f)-1.0f)*.01f; 


		//make the random noise thing back away from edge of the screen


		transform.Translate (new Vector3 (moveX, moveY, 0.0f));

	}
}
