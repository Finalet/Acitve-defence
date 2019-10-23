using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankProjectile : MonoBehaviour {
	GameObject Player;
	GameObject Tank;

	int hitStrength;
	// Use this for initialization
	void Awake () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Tank = GameObject.FindGameObjectWithTag ("tank");
		GetComponent<Rigidbody> ().AddForce (transform.up * (-1000));
	}

	void Start () {
		hitStrength = Tank.GetComponent<Tank> ().hitStrength;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "castle") {
			Player.GetComponent<Player> ().castleHP -= hitStrength;
			Destroy (gameObject);
		}
	}

	void Update () {
		//Physics.IgnoreCollision (Tank.GetComponent<Collider> (), GetComponent<Collider> ());
	}
}
