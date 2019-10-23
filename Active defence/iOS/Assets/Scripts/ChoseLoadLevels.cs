using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
public class ChoseLoadLevels : MonoBehaviour {
	public bool Load;

	public int level;
	public int maxLevel;
	public int levelToLoad;
	public GameObject Player;

	public void Restart () {
		SceneManager.LoadScene ("loadingGame");
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

	void CheckLevelChosen () {
		string path = pathForDocumentsFile ("ChoosingLevel.fin");
		FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
		StreamReader sr = new StreamReader (file);
		levelToLoad = System.Convert.ToInt32 (sr.ReadLine ());
		sr.Close ();
		file.Close ();


			
		//Debug.Log (Analytics.CustomEvent ("Load level", new Dictionary<string, object>{ {"firstObject", 10 } }));
	}
	public void ChoseLevel () {
		string path = pathForDocumentsFile ("ChoosingLevel.fin");
		FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		StreamWriter sw = new StreamWriter (file);
		sw.WriteLine (level);
		sw.Close ();
		file.Close ();
		SceneManager.LoadScene ("loadingGame");
	}


	void CheckMaxLevel () {
		string path = pathForDocumentsFile ("maxLevel.fin");
		if (File.Exists (path)) {
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			maxLevel = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			maxLevel = 0;
		}
	}
	public void writeMaxLevel () {
		if (levelToLoad >= maxLevel) {
			string path = pathForDocumentsFile ("maxLevel.fin");
			FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			StreamWriter sw = new StreamWriter (file);
			sw.WriteLine (levelToLoad);
			sw.Close ();
			file.Close ();
		}
	}

	void Awake () {
		CheckMaxLevel ();
		if (Load == true) {
			CheckLevelChosen ();
		} 
	}
	void Start () {
		if (Load == false) {
			if (maxLevel + 1 < level) {
				GetComponent<Image> ().color = Color.gray;
				GetComponent<Button> ().enabled = false;
			} else {
				GetComponent<Image> ().color = Color.white;
				GetComponent<Button> ().enabled = true;
			}
		}
	}

}
