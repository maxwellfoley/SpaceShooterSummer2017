using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInSCurve : MonoBehaviour {

	public Vector2 direction; 
	public float speed; 
	public float amplitude;
	public int period;
	int counter; 

	// Use this for initialization
	void Start () {
		counter = 0;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;

		Vector3 vec = new Vector3 (direction.x * speed, direction.y*speed, 0);
		Vector3 orthogonalVec = new Vector3 (-direction.y*speed,direction.x*speed,0);
		orthogonalVec = orthogonalVec * Mathf.Cos (((float)counter)/period) * amplitude;
		vec += orthogonalVec;
		vec.Normalize ();

		transform.Translate ( vec *speed );
	}
}
