using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphicsManager : MonoBehaviour {

	Animator cameraAnim;
	// Use this for initialization
	void Start () {
		GameObject camera = GameObject.Find ("MainCamera");
		Debug.Log (camera.GetComponent<Animator>());
		cameraAnim = camera.GetComponent<Animator> ();
	}

	public void animateHit() {
		cameraAnim.SetTrigger("PlayerHitTrigger");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
