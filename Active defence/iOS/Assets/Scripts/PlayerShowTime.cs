using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class PlayerShowTime : MonoBehaviour {
	public bool centerGunEnabled;
	public bool doubleGunsEnabled;
	public bool rocketsEnabled;
	public bool flamethrowerEnabled;
	public bool beamEnabled;
	public bool level1;
	public bool level2;
	public bool level3;
	public GameObject NOPE;
	public GameObject NOPEskill;

	public GameObject centerGun;
	public GameObject leftGun;
	public GameObject rightGun;
	public GameObject rockets;
	public GameObject flamethrower;
	public GameObject beam;

	[Header("Buttons")]
	public GameObject oneBullet;
	public GameObject twoBullets;
	public GameObject threeBullets;

	public GameObject rocketsButton;
	public GameObject fireButton;
	public GameObject beamButton;

	public GameObject oneDot;
	public GameObject twoDots;
	public GameObject threeDots;

	[Header("UpgradesInts")]
	int doubleGunsINT;
	int tripleGunsINT;
	int rocketsINT;
	int flamethrowerINT;
	int beamINT;
	int twoDotsINT;
	int threeDotsINT;



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

	public void Nope () {
		NOPE.SetActive (false);
		NOPEskill.SetActive (false);
	}


	void CheckDoubleGuns () {
		string path = pathForDocumentsFile ("doubleGuns.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			doubleGunsINT = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (0);
			sw.Close ();
			file.Close ();
		}
	}
	public void BuyDoubleGuns () {
		if (Camera.main.GetComponent<XP> ().skillPointNumber >= 1 && doubleGunsINT == 0) {
			string path = pathForDocumentsFile ("doubleGuns.fin");
			FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (1);
			sw.Close ();
			file.Close ();
			CheckDoubleGuns ();
			Camera.main.GetComponent<XP> ().RemoveSP ();
		} else {
			
			NOPEskill.SetActive (true);
		}
	}

	void CheckTripleGuns () {
		string path = pathForDocumentsFile ("tripleGuns.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			tripleGunsINT = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (0);
			sw.Close ();
			file.Close ();
		}
	}
	public void BuyTripleGuns () {
		if (doubleGunsINT == 1) {
			if (Camera.main.GetComponent<XP> ().skillPointNumber >= 1 && tripleGunsINT == 0) {
				string path = pathForDocumentsFile ("tripleGuns.fin");
				FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				StreamWriter sw = new StreamWriter (file);
				sw.WriteLine (1);
				sw.Close ();
				file.Close ();
				CheckTripleGuns ();
				Camera.main.GetComponent<XP> ().RemoveSP ();
			} else {
				
				NOPEskill.SetActive (true);
			}
		} else {
			NOPE.SetActive (true);
		}
	}

	void CheckRocketsGuns () {
		string path = pathForDocumentsFile ("rockets.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			rocketsINT = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (0);
			sw.Close ();
			file.Close ();
		}
	}
	public void BuyRocketsGuns () {
		if (Camera.main.GetComponent<XP> ().skillPointNumber >= 1 && rocketsINT == 0) {
			string path = pathForDocumentsFile ("rockets.fin");
			FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (1);
			sw.Close ();
			file.Close ();
			CheckRocketsGuns ();
			Camera.main.GetComponent<XP> ().RemoveSP ();
		} else {
			
			NOPEskill.SetActive (true);
		}
	}

	void CheckFlamethrowerGuns () {
		string path = pathForDocumentsFile ("flamethrower.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			flamethrowerINT = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (0);
			sw.Close ();
			file.Close ();
		}
	}
	public void BuyFlamethrowerGuns () {
		if (rocketsINT == 1) {
			if (Camera.main.GetComponent<XP> ().skillPointNumber >= 1 && flamethrowerINT == 0) {
				string path = pathForDocumentsFile ("flamethrower.fin");
				FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				StreamWriter sw = new StreamWriter (file);
				sw.WriteLine (1);
				sw.Close ();
				file.Close ();
				CheckFlamethrowerGuns ();
				Camera.main.GetComponent<XP> ().RemoveSP ();
			} else {
				
				NOPEskill.SetActive (true);
			}
		} else {
			NOPE.SetActive (true);
		}
	}

	void CheckBeamGuns () {
		string path = pathForDocumentsFile ("beam.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			beamINT = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (0);
			sw.Close ();
			file.Close ();
		}
	}
	public void BuyBeamGuns () {
		if (flamethrowerINT == 1) {
			if (Camera.main.GetComponent<XP> ().skillPointNumber >= 1 && beamINT == 0) {
				string path = pathForDocumentsFile ("beam.fin");
				FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				StreamWriter sw = new StreamWriter (file);
				sw.WriteLine (1);
				sw.Close ();
				file.Close ();
				CheckBeamGuns ();
				Camera.main.GetComponent<XP> ().RemoveSP ();
			} else {
				
				NOPEskill.SetActive (true);
			}
		} else {
			NOPE.SetActive (true);
		}
	}

	void CheckTwoDotsGuns () {
		string path = pathForDocumentsFile ("twoDots.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			twoDotsINT = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (0);
			sw.Close ();
			file.Close ();
		}
	}
	public void BuyTwoDotsGuns () {
		if (Camera.main.GetComponent<XP> ().skillPointNumber >= 1 && twoDotsINT == 0) {
			string path = pathForDocumentsFile ("twoDots.fin");
			FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (1);
			sw.Close ();
			file.Close ();
			CheckTwoDotsGuns ();
			Camera.main.GetComponent<XP> ().RemoveSP ();
		} else {
			
			NOPEskill.SetActive (true);
		}
	}

	void CheckThreeDotsGuns () {
		string path = pathForDocumentsFile ("threeDots.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			threeDotsINT = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (0);
			sw.Close ();
			file.Close ();
		}
	}
	public void BuyThreeDotsGuns () {
		if (twoDotsINT == 1) {
			if (Camera.main.GetComponent<XP> ().skillPointNumber >= 1 && threeDotsINT == 0) {
				string path = pathForDocumentsFile ("threeDots.fin");
				FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				StreamWriter sw = new StreamWriter (file);
				sw.WriteLine (1);
				sw.Close ();
				file.Close ();
				CheckThreeDotsGuns ();
				Camera.main.GetComponent<XP> ().RemoveSP ();
			} else {

				NOPEskill.SetActive (true);
			}
		} else {
			NOPE.SetActive (true);
		}
	}

	void Awake () {
		CheckDoubleGuns ();
		CheckTripleGuns ();
		CheckRocketsGuns ();
		CheckBeamGuns ();
		CheckFlamethrowerGuns ();
		CheckTwoDotsGuns ();
		CheckThreeDotsGuns ();
	}
	// Update is called once per frame
	void Update () {
		if (doubleGunsINT == 1 && tripleGunsINT != 1) {
			doubleGunsEnabled = true;
			centerGunEnabled = false;
		} else if (doubleGunsINT == 1 && tripleGunsINT == 1) {
			doubleGunsEnabled = true;
			centerGunEnabled = true;
		} else {
			doubleGunsEnabled = false;
		}

		if (rocketsINT == 1) {
			rocketsEnabled = true;
		} else {
			rocketsEnabled = false;
		}

		if (flamethrowerINT == 1) {
			flamethrowerEnabled = true;
		} else {
			flamethrowerEnabled = false;
		}

		if (beamINT == 1) {
			beamEnabled = true;
		} else {
			beamEnabled = false;
		}


		if (twoDotsINT != 1 && threeDotsINT != 1) {
			level1 = true;
			level2 = false;
			level3 = false;
		} else if (twoDotsINT == 1 && threeDotsINT != 1) {
			level1 = false;
			level2 = true;
			level3 = false;
		} else if (twoDotsINT == 1 && threeDotsINT == 1) {
			level1 = false;
			level2 = false;
			level3 = true;
		}






		if (centerGunEnabled == true) {
			centerGun.SetActive (true);
		} else {
			centerGun.SetActive (false);
		}
		if (doubleGunsEnabled == true) {
			leftGun.SetActive (true);
			rightGun.SetActive (true);
			twoBullets.GetComponent<Image> ().color = Color.white;
		} else {
			leftGun.SetActive (false);
			rightGun.SetActive (false);
			twoBullets.GetComponent<Image> ().color = Color.gray;
		}
		if (rocketsEnabled == true) {
			rockets.SetActive (true);
			rocketsButton.GetComponent<Image> ().color = Color.white;
		} else {
			rocketsButton.GetComponent<Image> ().color = Color.gray;
			rockets.SetActive (false);
		}
		if (flamethrowerEnabled == true) {
			flamethrower.SetActive (true);
			fireButton.GetComponent<Image> ().color = Color.white;
		} else {
			flamethrower.SetActive (false);
			fireButton.GetComponent<Image> ().color = Color.gray;
		}
		if (beamEnabled == true) {
			beam.SetActive (true);
			beamButton.GetComponent<Image> ().color = Color.white;
		} else {
			beam.SetActive (false);
			beamButton.GetComponent<Image> ().color = Color.gray;
		}
		transform.Rotate (transform.up * Time.deltaTime * 10);

		if (centerGunEnabled == true && doubleGunsEnabled == true) {
			threeBullets.GetComponent<Image> ().color = Color.white;
		} else {
			threeBullets.GetComponent<Image> ().color = Color.gray;
		}

		if (level1 == true) {
			oneDot.GetComponent<Image> ().color = Color.white;
			twoDots.GetComponent<Image> ().color = Color.gray;
			threeDots.GetComponent<Image> ().color = Color.gray;
		} else if (level2 == true) {
			oneDot.GetComponent<Image> ().color = Color.white;
			twoDots.GetComponent<Image> ().color = Color.white;
			threeDots.GetComponent<Image> ().color = Color.gray;
		} else if (level3 == true) {
			oneDot.GetComponent<Image> ().color = Color.white;
			twoDots.GetComponent<Image> ().color = Color.white;
			threeDots.GetComponent<Image> ().color = Color.white;
		}  




	}
}
