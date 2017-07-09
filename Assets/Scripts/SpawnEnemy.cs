using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public int frequency;
	public GameObject enemy; 

	int counter; 
	// Use this for initialization
	void Start () {
	 	counter = 0; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (counter % frequency == 0) {
			Instantiate (enemy, transform.position, transform.rotation);

		}
		counter++;

	}
}
