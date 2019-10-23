using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {
	


	public GameObject projectile;
	public GameObject projectileLeftSpawn;
	public GameObject projectileRightSpawn;
	public GameObject Player;
	public bool isSeen = true;
	public bool isAlive;
	public float direction;
	public float speed;

	public bool isHitting;
	bool one;
	[Header("Boss Number")]
	public int BossNumber;

	[Header("Characteristics")]
	public int HP;
	public int HP1;
	[Space]
	public int hitStrength;
	public int hitStrength1;
	// Use this for initialization


	void Start () {
		isAlive = true;
		Player = GameObject.FindGameObjectWithTag ("Player");
		HP = HP1;
		hitStrength = hitStrength1;
		StartCoroutine (Beginning1 ());
	}


	IEnumerator Beginning1 () {
		while (isAlive == true) {
			while (transform.position.y >= 0) {
				speed = 1;
				yield return null;
			}
			speed = 0;
			isHitting = true;
			while (transform.position.x >= -1.6) {
				direction = -1;
				yield return null;
			}
			while (transform.position.x <= 1.6) {
				direction = 1;
				yield return null;
			}
			yield return null;
		}
	}
	// Update is called once per frame
	void Update () {
		if (isAlive == true) {
			transform.position = new Vector3 (transform.position.x + direction * Time.deltaTime, transform.position.y + speed * Time.deltaTime * (-1), transform.position.z);
		}
		if (transform.position.y <= 4.5f ) {
			isSeen = true;
		}


		if (HP <= 0 && isAlive == true) {
			StartCoroutine (DEATH ());
			isAlive = false;
		}

		if (isHitting == true && one == false) {
			one = true;
			InvokeRepeating ("Hitting", 0, 1);
		}
		if (isHitting == false) {
			one = false;
			CancelInvoke ("Hitting");
		}
	}

	IEnumerator DEATH() {
		if (Camera.main.GetComponent<ChoseLoadLevels> ().levelToLoad == 13) {
			Player.GetComponent<XP> ().AddXP (50);
		}
		speed = 0;
		direction = 0;
		isHitting = false;
		while (transform.position.z <= 0.4) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * 1.5f);
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
		
		if (trig.gameObject.name == "fireTrigger") {
			if (isSeen == true) {
				StartCoroutine (FIRE ());
			}
		}
		if (trig.gameObject.name == "Sphere") {
			if (isSeen == true) {
				HP -= 40;
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
		yield return new WaitForSeconds (0.7f);
		HP -= 100;
	}


	void Hitting () {
		Instantiate (projectile, projectileLeftSpawn.transform.position, Quaternion.identity);
		Instantiate (projectile, projectileRightSpawn.transform.position, Quaternion.identity);
	}
}
