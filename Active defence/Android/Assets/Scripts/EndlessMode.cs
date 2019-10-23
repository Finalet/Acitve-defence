using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndlessMode : MonoBehaviour {
	public GameObject slider;
	public GameObject slider1;
	public GameObject slider2;
	public GameObject slider3;
	public GameObject MainCamera;
	// Use this for initialization
	public void PressStart () {
		if (slider.GetComponent<Slider> ().value != 0) {
			MainCamera.GetComponent<EndlessEnemySpawner> ().zornSpawnInterval = 3 - slider.GetComponent<Slider> ().value * 2.5f;
		}
		if (slider1.GetComponent<Slider> ().value != 0) {
			MainCamera.GetComponent<EndlessEnemySpawner> ().tankSpawnInterval = 40 - slider1.GetComponent<Slider> ().value * 38f;
			MainCamera.GetComponent<EndlessEnemySpawner> ().tankWhenStartSpawing = 0;
		}
		if (slider2.GetComponent<Slider> ().value != 0) {
			MainCamera.GetComponent<EndlessEnemySpawner> ().robotSpawnInterval = 40 - slider2.GetComponent<Slider> ().value * 38f;
			MainCamera.GetComponent<EndlessEnemySpawner> ().robotWhenStartSpawing = 3;
		}
		if (slider3.GetComponent<Slider> ().value != 0) {
			MainCamera.GetComponent<EndlessEnemySpawner> ().bossSpawnInterval = 40 - slider3.GetComponent<Slider> ().value * 38f;
			MainCamera.GetComponent<EndlessEnemySpawner> ().robotWhenStartSpawing = 6;
		}





		MainCamera.GetComponent<EndlessEnemySpawner> ().enabled = true;
		gameObject.SetActive (false);
	}
}
