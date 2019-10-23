using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1Projectile : MonoBehaviour {

	GameObject Player;
	GameObject Boss1;
	int hitStrength;
	// Use this for initialization
	void Awake () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Boss1 = GameObject.FindGameObjectWithTag ("BOSS");
		GetComponent<Rigidbody> ().AddForce (transform.up * (-300));
	}
	void Start () {
		hitStrength = Boss1.GetComponent<Boss1> ().hitStrength;
	}

	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "castle") {
			Player.GetComponent<Player> ().castleHP -= hitStrength;
			Destroy (gameObject);
		}
	}

	void Update () {
		//Physics.IgnoreCollision (Robot.GetComponent<Collider> (), GetComponent<Collider> ());
	}
}
