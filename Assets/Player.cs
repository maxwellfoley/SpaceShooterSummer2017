using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public Bullet bullet;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		transform.Translate (movement * speed);

		if (Input.GetKeyDown ("space")) {

			Debug.Log ("pressed space");

			Bullet myBullet = (Bullet)Instantiate(bullet, transform.position,transform.rotation);

			myBullet.direction = new Vector2(0,1);
			myBullet.speed = 0.5f;
		}
			
	}
}
