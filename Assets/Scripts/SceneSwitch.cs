using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	public void LoadMyScene(string name) {
		SceneManager.LoadScene (name);
	}

	public void LoadLastScene() {
		SceneManager.LoadScene (PlayerPrefs.GetString("PreviousScene"));
	}
}
