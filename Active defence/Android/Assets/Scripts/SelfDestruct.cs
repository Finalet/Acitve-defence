using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DIE ());
	}
	
	// Update is called once per frame
	IEnumerator DIE () {
		yield return new WaitForSeconds (0.01f);
		if (gameObject.name == "empty(Clone)") {
			Destroy (gameObject);
		}
	}
}
