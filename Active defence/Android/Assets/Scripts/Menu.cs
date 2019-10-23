using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour {
	public GameObject MenuGroup;
	public GameObject UpgradesGroup;
	public GameObject LevelsGroup;
	public GameObject ExperienceMenu;
	public GameObject lol;
	public GameObject model;
	public GameObject BLACK;
	public GameObject BLACK2;

	public bool upgrade;
	public bool menu1;
	public bool levels;
	public bool showXP;


	public void Button() {
		if (showXP == false) {
			showXP = true;
			ExperienceMenu.SetActive (true);
			lol.SetActive (true);
		} else {
			showXP = false;
			ExperienceMenu.SetActive (false);
			lol.SetActive (false);
		}
	}
	void Awake () {
		model.SetActive (true);
	}
	void Start () {
		model.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (menu1 == true) {
			
			MenuGroup.SetActive (true);
			UpgradesGroup.SetActive (false);
			LevelsGroup.SetActive (false);
			model.SetActive (false);

		} else if (upgrade == true) {
			
			MenuGroup.SetActive (false);
			UpgradesGroup.SetActive (true);
			model.SetActive (true);
			LevelsGroup.SetActive (false);

		} else if (levels == true) {
			
			MenuGroup.SetActive (false);
			UpgradesGroup.SetActive (false);
			model.SetActive (false);
			LevelsGroup.SetActive (true);

		}			
	}

	public void upgradesButton () {
		if (menu1 == true) {
			StartCoroutine (oneTowThree ());
		} else {
			StartCoroutine (oneThreeThree ());
		}
	}

	public void levelsButton () {
		if (menu1 == true) {
			StartCoroutine (oneOneThree ());
		} else {
			StartCoroutine (oneOneOne ());
		}
	}


	IEnumerator oneThreeThree () {
		BLACK.SetActive (false);
		BLACK2.SetActive (true);
		yield return new WaitForSeconds (0.3f);
		BLACK2.SetActive (false);
		BLACK.SetActive (true);
		menu1 = true;
		upgrade = false;
	}

	IEnumerator oneTowThree () {
		BLACK.SetActive (false);
		BLACK2.SetActive (true);
		yield return new WaitForSeconds (0.3f);
		BLACK2.SetActive (false);
		BLACK.SetActive (true);
		menu1 = false;
		upgrade = true;
	}

	IEnumerator oneOneThree () {
		BLACK.SetActive (false);
		BLACK2.SetActive (true);
		yield return new WaitForSeconds (0.3f);
		BLACK2.SetActive (false);
		BLACK.SetActive (true);
		menu1 = false;
		upgrade = false;
		levels = true;
	}
	IEnumerator oneOneOne () {
		BLACK.SetActive (false);
		BLACK2.SetActive (true);
		yield return new WaitForSeconds (0.3f);
		BLACK2.SetActive (false);
		BLACK.SetActive (true);
		menu1 = true;
		upgrade = false;
		levels = false;
	}
}
