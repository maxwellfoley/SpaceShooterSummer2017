using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector2 direction; 
	public float speed; 
	int counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (direction.x * speed, direction.y*speed, 0));
		counter++;

		if (counter > 100) {
			Object.Destroy (this.gameObject);
		}
	}


}
