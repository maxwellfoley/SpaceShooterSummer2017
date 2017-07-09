using UnityEngine;
using System.Collections;

public class ShootRegularly : MonoBehaviour {

	int counter;
	public GameObject bullet;
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
			GameObject myBullet = Instantiate (bullet, transform.position, transform.rotation);
			myBullet.GetComponent<MoveStraight>().direction = new Vector2 (0, -1);
			myBullet.GetComponent<MoveStraight>().speed = 0.05f;
		}
	}
}
