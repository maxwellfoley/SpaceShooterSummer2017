using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Destroy (other.gameObject);
			player.setScore (player.getScore () + 1);
		}
	}
}
