using UnityEngine;
using System.Collections;

public class ShootRegularly : MonoBehaviour {

	int counter;
	public Bullet bullet;
	public int frequency;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter % frequency == 0) {
			Bullet myBullet = (Bullet)Instantiate (bullet, transform.position, transform.rotation);
			myBullet.direction = new Vector2 (0, -1);
			myBullet.speed = 0.05f;
		}
	}
}
