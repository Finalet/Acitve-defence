using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewMenu : MonoBehaviour {
	public GameObject LevelsGroup;
	public GameObject MenuGroup;
	public GameObject UpgradeGroup;
	public GameObject ExperienceMenu;
	public GameObject moreMenu;
	public GameObject lol;
	public GameObject model;
	public GameObject BLACK;
	public GameObject BLACK2;
	public GameObject fadeImage;
	public GameObject fadeImage1;
	public GameObject moreKnopka;

	public GameObject OldCamera;
	public GameObject NewCamera;

	public GameObject OldCanvas;
	public GameObject newModel;

	public bool upgrade;
	public bool menu1;
	public bool levels;
	public bool more;
	public bool showXP;

	public string skipKongANDROID;
	public string cubismANDROID;
	public string quadrumTugANDROID;

	public string skipKongIOS;
	public string cubismIOS;
	public string quadrumTugIOS;

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
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (menu1 == true) {
			NewCamera.SetActive (true);
			MenuGroup.SetActive (true);
			LevelsGroup.SetActive (false);
			UpgradeGroup.SetActive (false);
			model.SetActive (false);
			OldCamera.SetActive (false);
			NewCamera.SetActive (true);
			moreMenu.SetActive (false);
			moreKnopka.SetActive (true);
		} else if (upgrade == true) {
			MenuGroup.SetActive (false);
			UpgradeGroup.SetActive (true);
			model.SetActive (true);
			LevelsGroup.SetActive (false);
			NewCamera.SetActive (false);
			OldCamera.SetActive (true);
			moreMenu.SetActive (false);
			moreKnopka.SetActive (false);

		} else if (levels == true) {
			NewCamera.SetActive (true);
			UpgradeGroup.SetActive (false);
			MenuGroup.SetActive (false);
			model.SetActive (false);
			LevelsGroup.SetActive (true);
			OldCamera.SetActive (false);
			moreMenu.SetActive (false);
			moreKnopka.SetActive (false);

		} else if (more == true) {
			NewCamera.SetActive (true);
			UpgradeGroup.SetActive (false);
			MenuGroup.SetActive (false);
			model.SetActive (false);
			LevelsGroup.SetActive (false);
			OldCamera.SetActive (false);
			moreMenu.SetActive (true);
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
			oneOneThree ();
		} else {
			oneOneOne ();
		}
	}

	public void moreButton () {
		if (more == true) {
			lolLollol ();
		} else {
			lolLol ();
		}
	}


	IEnumerator oneThreeThree () {
		BLACK.SetActive (false);
		BLACK2.SetActive (true);
		newModel.GetComponent<menuModel> ().CheckBeamGuns ();
		newModel.GetComponent<menuModel> ().CheckDoubleGuns ();
		newModel.GetComponent<menuModel> ().CheckRocketsGuns ();
		newModel.GetComponent<menuModel> ().CheckTripleGuns ();
		yield return new WaitForSeconds (0.4f);
		menu1 = true;
		upgrade = false;
		yield return new WaitForSeconds (0.01f);
		fadeImage1.SetActive (true);
		BLACK2.SetActive (false);
		BLACK.SetActive (false);
		moreKnopka.SetActive (true);
		yield return new WaitForSeconds (0.3f);
		fadeImage1.SetActive (false);
		BLACK.SetActive (false);
		BLACK2.SetActive (false);

	}

	IEnumerator oneTowThree () {
		fadeImage.SetActive (false);
		moreKnopka.SetActive (false);
		yield return new WaitForSeconds (0.3f);
		menu1 = false;
		upgrade = true;
		yield return new WaitForSeconds (0.01f);
		fadeImage.SetActive (false);
		BLACK.SetActive (true);
		yield return new WaitForSeconds (0.4f);
		BLACK.SetActive (false);
	}

	void oneOneThree () {

		menu1 = false;
		upgrade = false;
		levels = true;
	}
	void oneOneOne () {

		menu1 = true;
		upgrade = false;
		levels = false;
	}

	void lolLol () {
		menu1 = false;
		upgrade = false;
		levels = false;
		more = true;
	}

	void lolLollol () {
		menu1 = true;
		upgrade = false;
		levels = false;
		more = false;
	}

	public void OpenCubism () {
		if (Application.platform == RuntimePlatform.Android) {
			Application.OpenURL (cubismANDROID);
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Application.OpenURL (cubismIOS);
		} else {
			Application.OpenURL ("http://finale.cc/cubism");
		}
	}
	public void OpenSkipKong () {
		if (Application.platform == RuntimePlatform.Android) {
			Application.OpenURL (skipKongANDROID);
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Application.OpenURL (skipKongIOS);
		} else {
			Application.OpenURL ("http://finale.cc/skip_kong");
		}
	}
	public void OpenQuadrumTug () {
		if (Application.platform == RuntimePlatform.Android) {
			Application.OpenURL (quadrumTugANDROID);
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			Application.OpenURL (quadrumTugIOS);
		} else {
			Application.OpenURL ("http://finale.cc/quadrum_tug");
		}
	}
}
