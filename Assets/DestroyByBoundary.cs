using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log (other.tag);
		if (other.tag == "Bullet" || other.tag == "Enemy") {
			Destroy (other.gameObject);
	
		}
	}
}
