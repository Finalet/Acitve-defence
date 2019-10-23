using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public GameObject Player;
	public int speed;

	// Use this for initialization

	void Awake () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		speed = Player.GetComponent<Player> ().projectileSpeed;
	}


	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.up * speed * 100);
		StartCoroutine (DIE ());
	}
	
	IEnumerator DIE () {
		yield return new WaitForSeconds (5);
		Destroy (gameObject);
	}

}
