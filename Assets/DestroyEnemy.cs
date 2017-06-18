using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	Text ScoreText;
	int score;
	// Use this for initialization
	void Start () {
		score = 0;
		ScoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Destroy (other.gameObject);
			score++;
			Debug.Log (score);
  			ScoreText.text = "Score " + score;
		}
	}
}
