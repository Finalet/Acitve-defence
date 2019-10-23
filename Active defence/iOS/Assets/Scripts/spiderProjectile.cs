using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderProjectile : MonoBehaviour {
	GameObject Player;
	GameObject Robot;
	int hitStrength;
	// Use this for initialization
	void Awake () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Robot = GameObject.FindGameObjectWithTag ("robot");
		GetComponent<Rigidbody> ().AddForce (transform.up * (-300));
	}
	void Start () {
		hitStrength = Robot.GetComponent<SpiderRobot> ().hitStrength;
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
