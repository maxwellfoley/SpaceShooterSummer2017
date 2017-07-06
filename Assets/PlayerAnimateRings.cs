using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimateRings : MonoBehaviour {

	Transform[] rings = new Transform[3];
	// Use this for initialization
	void Start () {
		rings [0] = transform.Find ("PlayerRing0");
		rings [1] = transform.Find ("PlayerRing1");
		rings [2] = transform.Find ("PlayerRing2");
	}
	
	// Update is called once per frame
	void Update () {
		rings [0].Rotate (0.1f, 0, 0.1f);
		rings [1].Rotate (0.1f, 0, 0.1f);
		rings[2].Rotate(0.1f,0,0.1f);

	}
}
