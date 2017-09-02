using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		//disable all enemies 
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag ("Enemy")) {
			Debug.Log("disable time");

			MonoBehaviour[] scripts = enemy.GetComponentsInChildren<MonoBehaviour>();
			foreach (MonoBehaviour item in scripts) {
				item.enabled = false;
			}
		}


	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Bullet" || other.tag == "Enemy") {
			Destroy (other.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(" on enter " + other.tag);

		if (other.tag == "Pauser") {
			Debug.Log(" on pauser enter " );
			PauseLevel p = other.GetComponent<PauseLevel> ();
			p.OnEnter ();
		}

		if (other.tag == "Enemy") {
			//enable it 

			Debug.Log("enable time");
			MonoBehaviour[] scripts = other.GetComponentsInChildren<MonoBehaviour>();
			foreach (MonoBehaviour item in scripts) {
				item.enabled = true;
			}

		}
	}
}
