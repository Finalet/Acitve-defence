using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zorn : MonoBehaviour {
	[Header("Characteristics")]
	public int HP;
	public int hitStrength;
	public float movementSpeed;
	public GameObject Player;
	bool one;
	public bool isSeen;
	public bool Alive;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= 4) {
			isSeen = true;
		}

		transform.position = new Vector3 (transform.position.x, transform.position.y - movementSpeed * Time.deltaTime, transform.position.z);

		if (HP <= 0 && Alive == true) {
			StartCoroutine (DEATH ());
			Alive = false;
		}
		GetComponent<Animator> ().SetInteger ("HP", HP);
	}
	IEnumerator DEATH (){
		if (Camera.main.GetComponent<ChoseLoadLevels> ().levelToLoad == 13) {
			Player.GetComponent<XP> ().AddXP (10);
		}
		movementSpeed = 0;
		GetComponent<BoxCollider> ().enabled = false;
		CancelInvoke ();
		yield return new WaitForSeconds (3);
		while (transform.position.z <= -0.25) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * 0.2f);
			yield return null;
		}
		Destroy (gameObject);
	}
	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.name == "projectile(Clone)") {
			if (isSeen == true) {
				HP-= 10;
				Destroy (coll.gameObject);
			} else {
				Destroy (coll.gameObject);
			}
		}

		if (coll.gameObject.tag == "castle" && one == false) {
			GetComponent<Animator> ().SetBool ("trigger", true);
			InvokeRepeating ("Hit", 0.4f, 1.2f);
			movementSpeed = 0;
			one = true;
		}
	}
	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.name == "fireTrigger") {
			if (isSeen == true) {
				StartCoroutine (FIRE ());
			}
		}
		if (coll.gameObject.name == "Sphere") {
			if (isSeen == true) {
				HP-=10;
			}
		}

	}
	void OnTriggerStay (Collider coll){
		if (coll.gameObject.tag == "beam") {
			if (isSeen == true) {
				HP-=10;
			}
		}
	}

	IEnumerator FIRE () {
		yield return new WaitForSeconds (0.3f);
		HP-=100;
	}

	void Hit () {
		Player.GetComponent<Player> ().castleHP -= hitStrength;
	}
}
