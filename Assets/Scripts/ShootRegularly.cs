using UnityEngine;
using System.Collections;

public class ShootRegularly : MonoBehaviour {

	int counter;
	public Bullet bullet;
	public int frequency;
	int offset;

	// Use this for initialization
	void Start () {
		counter = 0;
		offset = (int)(Random.value*frequency);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		if (counter % frequency == offset) {
			Bullet myBullet = (Bullet)Instantiate (bullet, transform.position, transform.rotation);
			myBullet.direction = new Vector2 (0, -1);
			myBullet.speed = 0.05f;
		}
	}
}
