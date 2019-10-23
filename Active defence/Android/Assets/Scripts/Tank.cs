using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

	public int HP;
	public float movementSpeed;
	public int hitStrength;
	bool isHitting = false;

	public GameObject Player;
	public GameObject projectile;
	public GameObject left;
	public GameObject right;
	public bool Alive;
	public bool isSeen;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y - movementSpeed * Time.deltaTime, transform.position.z);

		if (HP <= 0 && Alive == true) {
			StartCoroutine (DEATH ());
			Alive = false;
		}
		if (transform.position.y <= 4.5) {
			isSeen = true;
		}
	}

	IEnumerator DEATH () {
		if (Camera.main.GetComponent<ChoseLoadLevels> ().levelToLoad == 13) {
			Player.GetComponent<XP> ().AddXP (30);
		}
		movementSpeed = 0;
		while (transform.position.z <= 0.7) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * 1.6f);
			yield return null;
		}
		Destroy (gameObject);
	}

	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.name == "projectile(Clone)") {
			if (isSeen == true) {
				HP--;
				Destroy (coll.gameObject);
			} else {
				Destroy (coll.gameObject);
			}
		}

	}

	void OnTriggerEnter (Collider trig) {
		if (trig.name == "tankTrigger" && isHitting == false) {
			InvokeRepeating ("Hitting", 0, 3);
			isHitting = true;
			movementSpeed = 0;
		}
		if (trig.gameObject.name == "fireTrigger") {
			if (isSeen == true) {
				StartCoroutine (FIRE ());
			}
		}
		if (trig.gameObject.name == "Sphere") {
			if (isSeen == true) {
				HP -= 30;
			}
		}

	}
	void OnTriggerStay(Collider trig) {
		if (trig.gameObject.tag == "beam") {
			if (isSeen == true) {
				HP -= 200;
			}
		}
	}

	IEnumerator FIRE () {
		yield return new WaitForSeconds (2);
		HP -= 100;
	}

	void Hitting () {
		
		Instantiate (projectile, left.transform.position, Quaternion.identity);
		Instantiate (projectile, right.transform.position, Quaternion.identity);
		GetComponent<Animation> ().Play ("tankRecoil");
	}
}
