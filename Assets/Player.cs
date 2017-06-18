using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector2 speed;
	Vector3 speed3;
	public Bullet bullet;
	public int maxHealth;
	int health;
	int score;
	GameObject GameArea;
	BoxCollider GameAreaCollider; 
	public Text HealthText;
	public Text ScoreText;


	// Use this for initialization
	void Start () {
		GameArea = GameObject.Find ("GameArea"); 
		GameAreaCollider = GameArea.GetComponent<BoxCollider>(); 
		this.setHealth(maxHealth);
		speed3 = new Vector3 (speed.x, speed.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveHorizontal != 0 || moveVertical != 0) {
			
			Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

			//check whether or not the player will be moving out of bounds
			Vector3 currentPosition = transform.position;
			Vector3 speedMovement = new Vector3 (movement.x * speed.x, movement.y * speed.y, 0.0f);
			Vector3 futurePosition = currentPosition + speedMovement; 

			bool movementInBounds = GameAreaCollider.bounds.Contains (futurePosition);

			if (movementInBounds) {
				transform.Translate (speedMovement);
			}

			if (health <= 0) {
				//Object.Destroy (this.gameObject);
				GameObject.Find("Master").GetComponent<GameManager>().GameOver();
			}
		}

		if (Input.GetKeyDown ("space")) {

			Bullet myBullet = (Bullet)Instantiate (bullet, transform.position, transform.rotation);
			myBullet.direction = new Vector2 (0, 1);
			myBullet.speed = 0.05f;
		}

	}

	public int getHealth() {
		return health;
	}

	public void setHealth(int i){
		health = i;
		HealthText.text = "health " + i.ToString();
	}

	public int getScore() {
		return score;
	}

	public void setScore(int i) {
		score = i;
		ScoreText.text = "score " + i.ToString(); 
	}
}
