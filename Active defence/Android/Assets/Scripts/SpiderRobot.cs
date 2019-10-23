using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderRobot : MonoBehaviour {


	[Header("Characteristics")]
	public int HP;

	[Space]

	public float speed;
	public float direction;
	public int hitStrength;

	[Header("Booleans")]
	public bool idle;
	public bool isHitting;
	bool one;
	public bool isSeen;

	public GameObject guns;
	public GameObject projectile;
	public GameObject oneone;

	public bool Alive;
	GameObject Player;
	void Start () {
		StartCoroutine (AI ());
		Player = GameObject.FindGameObjectWithTag ("Player");
		Alive = true;
	}
	IEnumerator DEATH () {
		if (Camera.main.GetComponent<ChoseLoadLevels> ().levelToLoad == 13) {
			Player.GetComponent<XP> ().AddXP (30);
		}
		isHitting = false;
		direction = 0;
		speed = 0;
		while (transform.position.z <= 0.8f) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * 1.5f);
			yield return null;
		}
		Destroy (gameObject);
	}
	void Update () {

		if (transform.position.y <= 4) {
			isSeen = true;
		}

		if (HP <= 0 && Alive == true) {
			StartCoroutine (DEATH ());
			Alive = false;
		}


		Animator anim = GetComponent<Animator> ();
		if (Input.GetKeyDown (KeyCode.W) || speed > 0) {
			anim.SetFloat ("Speed", 1);
		} else if (Input.GetKeyDown (KeyCode.S) || speed < 0) {
			anim.SetFloat ("Speed", -1);
		} else if (Input.GetKeyDown (KeyCode.A) || direction > 0) {
			anim.SetFloat ("Direction", 1);
		} else if (Input.GetKeyDown (KeyCode.D) || direction < 0) {
			anim.SetFloat ("Direction", -1);
		} 

		if (speed == 0 && direction == 0) {
			idle = true;
		} else {
			idle = false;
		}
		if (idle == true) {
			anim.SetBool ("Idle", true);
			anim.SetFloat ("Direction", 0);
			anim.SetFloat ("Speed", 0);
		
		} else {
			anim.SetBool ("Idle", false);

		}

		transform.position = new Vector3 (transform.position.x + direction * Time.deltaTime, transform.position.y + speed * Time.deltaTime * (-1), transform.position.z);

		if (transform.position.x <= -1.75 || transform.position.x >= 1.75) {
			direction = 0;
		} 
		if (transform.position.y <= -1.25) {
			speed = 0;
		}


		if (isHitting == true && one == false) {
			one = true;
			InvokeRepeating ("Hitting", 0, 0.1f);
		}
		if (isHitting == false) {
			one = false;
			CancelInvoke ("Hitting");
		}
		if (isHitting == true) {
			guns.transform.Rotate (Vector3.up * Time.deltaTime * 300, Space.World);
		}
	}

	void Hitting () {
		Instantiate (projectile, oneone.transform.position, Quaternion.identity);
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
	void OnTriggerStay (Collider coll) {
		if (coll.gameObject.name == "Sphere") {
			if (isSeen == true) {
				HP -= 100;
			}
		}
		if (coll.gameObject.tag == "beam") {
			if (isSeen == true) {
				HP-=100;
			}
		}
		if (coll.gameObject.name == "fireTrigger") {
			if (isSeen == true) {
				StartCoroutine (FIRE ());
			}
		}
	}

	IEnumerator FIRE () {
		yield return new WaitForSeconds (0.5f);
		HP -= 100;
	}


	void OnTriggerEnter (Collider coll) {
		
	}

	IEnumerator AI () {
		if (Alive == true) {
			float x = Random.Range (-1.0f, 1.0f);

			speed = 3;
			yield return new WaitForSeconds (Random.Range (0.5f, 2.0f));
			speed = 0;
			isHitting = true;

			yield return new WaitForSeconds (2);
			if (x > 0) {
				direction = 3;
			} else {
				direction = -3;
			}
			isHitting = false;
			yield return new WaitForSeconds (Random.Range (0.5f, 1.3f));
			direction = 0;
			isHitting = true;
		}


		while (gameObject.activeInHierarchy == true && Alive == true) {
			yield return new WaitForSeconds (2);
			isHitting = false;
			float y = Random.Range (-1.0f, 1.0f);
			if (y > 0) {
				if (transform.position.x > 0) {
					direction = -3;
				} else {
					direction = 3;
				}
			} else {
				if (transform.position.y <= 0.7) {
					speed = -3;
				} else {
					speed = 3;
				}
				if (transform.position.x > 0) {
					direction = -3;
				} else {
					direction = 3;
				}
			}
			yield return new WaitForSeconds (Random.Range (0.5f, 1.3f));
			direction = 0;
			speed = 0;
			isHitting = true;
		}
	}

}
