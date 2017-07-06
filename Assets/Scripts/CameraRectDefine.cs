using UnityEngine;
using System.Collections;

public class CameraRectDefine : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera camera = GetComponent<Camera>();

		Rect rect = camera.rect;

		rect.width = Screen.width;
		rect.height = Screen.height;
		rect.x = 0;
		rect.y = 0;

		camera.rect = rect;
	}
}
