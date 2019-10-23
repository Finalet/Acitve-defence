using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour {
	public bool isPaused;
	public GameObject PauseMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused == true) {
			Time.timeScale = 0;
			PauseMenu.SetActive (true);
		} else {
			Time.timeScale = 1;
			PauseMenu.SetActive (false);
		}
	}

	public void PauseButton () {
		if (isPaused == true) {
			isPaused = false;
		} else {
			isPaused = true;
		}
	}

	public void MainMenu () {
		SceneManager.LoadScene ("loadingMenu");
	}
}
