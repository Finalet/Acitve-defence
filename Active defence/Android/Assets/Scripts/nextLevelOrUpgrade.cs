using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class nextLevelOrUpgrade : MonoBehaviour {
	public GameObject Upgrade;
	public GameObject nextLevel;
	public GameObject nextLevelBig;

	public GameObject Player;


	void Start () {
		
	}
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
	
	// Update is called once per frame
	void Update () {
		if (Player.GetComponent<XP> ().skillPointNumber > 0) {
			Upgrade.SetActive (true);
			nextLevel.SetActive (true);
			nextLevelBig.SetActive (false);
		} else {
			Upgrade.SetActive (false);
			nextLevel.SetActive (false);
			nextLevelBig.SetActive (true);
		}
	}
		
	public void nextLevelVoid () {
		string path = pathForDocumentsFile ("ChoosingLevel.fin");
		FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		StreamWriter sw = new StreamWriter (file);
		sw.WriteLine (Camera.main.GetComponent<ChoseLoadLevels>().levelToLoad + 1);
		sw.Close ();
		file.Close ();
		SceneManager.LoadScene ("loadingGame");
	}

	public void goToUpgrade() {
		SceneManager.LoadScene ("loadingSkills");
	}
}
