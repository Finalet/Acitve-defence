using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	public Transform target1right;
	public Transform target1left;
	public Transform target2right;
	public Transform target2left;
	public Transform target3right;
	public Transform target3left;
	public bool left;
	public bool right;
	public GameObject Sphere;
	public GameObject Explosion;

	public float speed;
	// Use this for initialization
	void OnEnable () {
		StartCoroutine (Fire ());
	}
	
	// Update is called once per frame
	IEnumerator Fire () {

		if (right == true) {
			yield return new WaitForSeconds (0.15f);
			while (transform.position != target1right.position) {
				transform.position = Vector3.MoveTowards (transform.position, target1right.position, speed * Time.deltaTime);
				transform.LookAt (target1right);
				yield return null;
			}
			while (transform.position != target2right.position) {
				transform.position = Vector3.MoveTowards (transform.position, target2right.position, speed * Time.deltaTime);
				transform.LookAt (target2right);
				yield return null;
			}
			while (transform.position != target3right.position) {
				transform.position = Vector3.MoveTowards (transform.position, target3right.position, speed * Time.deltaTime);
				transform.LookAt (target3right);
				yield return null;
			}
			gameObject.SetActive (false);
		} else {
			while (transform.position != target1left.position) {
				transform.position = Vector3.MoveTowards (transform.position, target1left.position, speed * Time.deltaTime);
				transform.LookAt (target1left);
				yield return null;
			}
			while (transform.position != target2left.position) {
				transform.position = Vector3.MoveTowards (transform.position, target2left.position, speed * Time.deltaTime);
				transform.LookAt (target2left);
				yield return null;
			}
			Sphere.SetActive (true);
			Explosion.SetActive (false);
			Explosion.SetActive (true);
			while (transform.position != target3left.position) {
				transform.position = Vector3.MoveTowards (transform.position, target3left.position, speed * Time.deltaTime);
				transform.LookAt (target3left);
				yield return null;
			}
			Sphere.SetActive (false);
			gameObject.SetActive (false);
		}
	}
}
