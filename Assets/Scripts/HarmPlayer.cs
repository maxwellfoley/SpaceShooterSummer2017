using UnityEngine;
using System.Collections;

public class HarmPlayer : MonoBehaviour {

	GameObject master;
	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Master");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Player player = other.gameObject.GetComponent(typeof (Player)) as Player;
			player.setHealth (player.getHealth()- 1);
			other.GetComponent<PlayerGraphicsManager> ().animateHit();
		}

		Destroy (this.gameObject);
	}

}
