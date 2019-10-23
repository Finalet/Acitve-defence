using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class menuModel : MonoBehaviour {
	public bool centerGunEnabled;
	public bool doubleGunsEnabled;
	public bool rocketsEnabled;
	public bool beamEnabled;

	public GameObject centerGun;
	public GameObject leftGun;
	public GameObject rightGun;
	public GameObject rockets;

	int doubleGunsINT;
	int tripleGunsINT;
	int rocketsINT;
	int beamINT;


	[Header("Materials")]
	public Material Cyan;
	public Material Red;
	public GameObject centerMat;
	public GameObject leftMat;
	public GameObject rightMat;

	void Awake () {
		CheckDoubleGuns ();
		CheckTripleGuns ();
		CheckBeamGuns ();
		CheckRocketsGuns ();
	}


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

	public void CheckBeamGuns () {
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
	public void CheckRocketsGuns () {
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
	public void CheckTripleGuns () {
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
	public void CheckDoubleGuns () {
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
			centerGunEnabled = true;
		}

		if (rocketsINT == 1) {
			rocketsEnabled = true;
		} else {
			rocketsEnabled = false;
		}

		if (beamINT == 1) {
			beamEnabled = true;
		} else {
			beamEnabled = false;
		}
			

		if (centerGunEnabled == true) {
			centerGun.SetActive (true);
		} else {
			centerGun.SetActive (false);
		}
		if (doubleGunsEnabled == true) {
			leftGun.SetActive (true);
			rightGun.SetActive (true);

		} else {
			leftGun.SetActive (false);
			rightGun.SetActive (false);
	
		}
		if (rocketsEnabled == true) {
			rockets.SetActive (true);
		} else {
			rockets.SetActive (false);
		}

		if (beamEnabled == true) {
			
			centerMat.GetComponent<MeshRenderer> ().material = Red;
			leftMat.GetComponent<MeshRenderer> ().material = Red;
			rightMat.GetComponent<MeshRenderer> ().material = Red;
		} else{
			
			centerMat.GetComponent<MeshRenderer> ().material = Cyan;
			leftMat.GetComponent<MeshRenderer> ().material = Cyan;
			rightMat.GetComponent<MeshRenderer> ().material = Cyan;
		}
	}
}
