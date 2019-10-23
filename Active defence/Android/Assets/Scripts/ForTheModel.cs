using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTheModel : MonoBehaviour {

	public GameObject model;
	public bool Zorn;
	public bool Tank;
	public bool SpiderRobot;
	
	// Update is called once per frame
	void OnBecameVisible () {
		StartCoroutine (LOL ());
	}

	IEnumerator LOL () {
		yield return new WaitForSeconds (3f);
		if (Zorn == true) {
			model.GetComponent<Zorn> ().isSeen = true;
		} else if (Tank == true) {
			model.GetComponent<Tank> ().isSeen = true;
		} else if (SpiderRobot == true) {
			model.GetComponent<SpiderRobot> ().isSeen = true;
		}
	}
}
