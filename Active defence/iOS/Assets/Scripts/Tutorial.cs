using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;



public class Tutorial : MonoBehaviour {
	public GameObject button;
	public GameObject backGround;
	public GameObject Zorn;
	public GameObject flameThrower;
	public GameObject Player;
	public GameObject Finger;
	public GameObject HP;
	public GameObject PauseButton;
	public Text text;
	int pressNumber;


	public string pathForDocumentsFile( string filename ) { 
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			string path = Application.persistentDataPath.Substring( 0, Application.persistentDataPath.Length - 5 );
			path = path.Substring( 0, path.LastIndexOf( '/' ) );
			return Path.Combine( Path.Combine( path, "Documents" ), filename );
		} else if (Application.platform == RuntimePlatform.Android) {
			string path = Application.persistentDataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ) );	
			return Path.Combine (path, filename);
		} else {
			string path = Application.dataPath;	
			path = path.Substring(0, path.LastIndexOf( '/' ) );
			return Path.Combine (path, filename);
		}
	}

	public void writeTutorial () {
		string path = pathForDocumentsFile ("tutorial.fin");
		FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		StreamWriter sw = new StreamWriter (file);
		sw.WriteLine ("1");
		sw.Close ();
		file.Close ();
	}

	void Start () {
		PauseButton.SetActive (false);
		HP.SetActive (false);
		pressNumber = 0;
	}
	
	// Update is called once per frame
	public IEnumerator tut() {
		text.text = "Welcome to\nActive Defence!";
		yield return new WaitForSeconds (2);

		button.SetActive (true);
		while (pressNumber == 0) {
			yield return null;
		}
		button.SetActive (false);

		text.text = "Hold your turret and move it left and right across the screen";
		Finger.SetActive (true);
		Finger.GetComponent<Animator> ().SetTrigger ("dragTurret");
		yield return new WaitForSeconds(10);
		text.text = "Now try killing couple of enemies";
		Finger.SetActive (false);
		yield return new WaitForSeconds (2);
		button.SetActive (true);
		while (pressNumber == 1) {
			yield return null;
		}
		button.SetActive (false);

		text.text = "";
		backGround.SetActive (false);
		Instantiate (Zorn, new Vector3 (-1.5f, 7, -0.485f), Quaternion.Euler(90, 180, 0));
		yield return new WaitForSeconds (1);
		Instantiate (Zorn, new Vector3 (0, 7, -0.485f), Quaternion.Euler(90, 180, 0));
		yield return new WaitForSeconds (1);
		Instantiate (Zorn, new Vector3 (1.5f, 7, -0.485f), Quaternion.Euler(90, 180, 0));

		GameObject[] Zorns = GameObject.FindGameObjectsWithTag ("zorn");
		while (Zorns.Length != 0) {
			Zorns = GameObject.FindGameObjectsWithTag ("zorn");
			yield return new WaitForSeconds (0.5f);
		}

		text.text = "Great job!";
		backGround.SetActive (true);
		yield return new WaitForSeconds (1);

		button.SetActive (true);
		while (pressNumber == 2) {
			yield return null;
		}
		button.SetActive (false);

		Player.GetComponent<Player> ().flamethrowerEnabled = true;
		text.text = "Next, drag a skill icon anywhere into the field to use a special ability";
		Finger.SetActive (true);
		Finger.GetComponent<Animator> ().SetTrigger ("dragSkill");
		yield return new WaitUntil (() => flameThrower.activeInHierarchy == true);
		Finger.SetActive (false);
		text.text = "Awesome!";
		Instantiate (Zorn, new Vector3 (-1.5f, 7, -0.485f), Quaternion.Euler(90, 180, 0));
		yield return new WaitForSeconds (1);
		Instantiate (Zorn, new Vector3 (0, 7, -0.485f), Quaternion.Euler(90, 180, 0));
		yield return new WaitForSeconds (1);
		Instantiate (Zorn, new Vector3 (1.5f, 7, -0.485f), Quaternion.Euler(90, 180, 0));
		yield return new WaitForSeconds (1);
		Instantiate (Zorn, new Vector3 (-1.2f, 7, -0.485f), Quaternion.Euler(90, 180, 0));
		yield return new WaitForSeconds (1);
		Instantiate (Zorn, new Vector3 (-0.5f, 7, -0.485f), Quaternion.Euler(90, 180, 0));
		yield return new WaitForSeconds (1);
		Instantiate (Zorn, new Vector3 (1.7f, 7, -0.485f), Quaternion.Euler(90, 180, 0));


		button.SetActive (true);
		while (pressNumber == 3) {
			yield return null;
		}
		button.SetActive (false);

		text.text = "Now you are ready for the world of Active Defence!";

		yield return new WaitForSeconds (2);
		button.SetActive (true);
		while (pressNumber == 4) {
			yield return null;
		}
		button.SetActive (false);

		writeTutorial ();
		SceneManager.LoadScene ("loadingMenu");
	}


	public void Button () {
		pressNumber++;
	}
}
