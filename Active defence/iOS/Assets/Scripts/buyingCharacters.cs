using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class buyingCharacters : MonoBehaviour {
	public Text dinoPrice;
	public Text kittyPrice;

	public int dinoBought;
	public int kittyBought;

	// Use this for initialization
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
	void Start () {
		CheckDino ();
		CheckKitty ();
	}
	void CheckKitty () {
		string path = pathForDocumentsFile ("kitty.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			kittyBought = System.Convert.ToInt32 (sr.ReadLine ());
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
	void CheckDino () {
		string path = pathForDocumentsFile ("dino.fin");
		if (File.Exists (path)) {

			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			dinoBought = System.Convert.ToInt32 (sr.ReadLine ());
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
	
	void Update () {
		if (dinoBought == 0) {
			dinoPrice.text = "20.000 UNITS";
		} else {
			dinoPrice.text = "DINO";
		}
		if (kittyBought == 0) {
			kittyPrice.text = "20.000 UNITS";
		} else {
			kittyPrice.text = "KITTY";
		}
	}
}
