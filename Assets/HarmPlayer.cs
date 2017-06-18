using UnityEngine;
using System.Collections;

public class HarmPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
		}
	}

}
