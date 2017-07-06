using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector2 direction; 
	public float speed; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (new Vector3 (direction.x * speed, direction.y*speed, 0));
	}


}
