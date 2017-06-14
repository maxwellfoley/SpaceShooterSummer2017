using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public Bullet bullet;
	GameObject GameArea;
	BoxCollider GameAreaCollider; 

	// Use this for initialization
	void Start () {
		GameArea = GameObject.Find ("GameArea"); 
		GameAreaCollider = GameArea.GetComponent<BoxCollider>(); 
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");


		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		//check whether or not the player will be moving out of bounds
		Vector3 currentPosition = transform.position;
		Vector3 futurePosition = currentPosition + (movement * speed); 

		bool movementInBounds = GameAreaCollider.bounds.Contains (futurePosition);

		if(movementInBounds) transform.Translate (movement * speed);

		if (Input.GetKeyDown ("space")) {

			Bullet myBullet = (Bullet)Instantiate(bullet, transform.position,transform.rotation);
			myBullet.direction = new Vector2(0,1);
			myBullet.speed = 0.05f;
		}
			
	}
}
