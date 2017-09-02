using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderMover : MonoBehaviour {

	int counter; 
	int counterBuf; 
	Vector2 velocity;
	Vector2 target;
	public float speed;
	int timeBetweenTargetChange = 100;

	// Use this for initialization
	void Start () {
		counter = 0;
		counterBuf = 0;
		velocity = new Vector2 (0.0f, 0.0f);
		target = GenerateTarget ();
	}

	Vector2 GenerateTarget()
	{
		//Debug.Log("generate target");
		return new Vector2 ((Random.value * 2.0f) - 1.0f, (Random.value * 2.0f) - 1.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		counter++;

		//if a certain amount of time has elapsed, pick a new random target
		if (counter > counterBuf + timeBetweenTargetChange) {
			//Debug.Log ("time elapsed " + counter);
			target = GenerateTarget ();
			counterBuf = counter;
		}

		//if the object is close to the target, pick a new random target
		else if (Vector2.Distance(target,new Vector2(transform.position.x,transform.position.y)) < .005)
		{
			//Debug.Log ("too close " + Vector2.Distance (target, new Vector2 (transform.position.x, transform.position.y)));
			target = GenerateTarget ();
			counterBuf = counter;
		}

		//steer towards target and move
		Vector2 desiredVelocity = target - 
			new Vector2(transform.position.x, transform.position.y);
		
		desiredVelocity.Normalize ();

		Vector2 steering = desiredVelocity - velocity;
		Vector2 finalVelocity = velocity + steering; 


		finalVelocity.Normalize ();
		velocity = finalVelocity * speed;

		transform.Translate (new Vector3 (velocity.x, velocity.y, 0.0f));

	}
}
