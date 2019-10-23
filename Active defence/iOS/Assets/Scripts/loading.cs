using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class loading : MonoBehaviour {
	public bool Game;
	public bool Skills;
	public bool Menu;

	public RectTransform progressBar;
	int tut;
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

	void CheckTutorial () {
		string path = pathForDocumentsFile ("tutorial.fin");
		if (File.Exists (path)) {
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			tut = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			tut = 0;
		}
	}

	public void ChoseLevel () {
		string path = pathForDocumentsFile ("ChoosingLevel.fin");
		FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		StreamWriter sw = new StreamWriter (file);
		sw.WriteLine (15);
		sw.Close ();
		file.Close ();
	}


	// Use this for initialization
	void Start () {
		StartCoroutine (Load ());
	}
	
	// Update is called once per frame
	IEnumerator Load () {
		if (Game == true) {
			AsyncOperation lol = SceneManager.LoadSceneAsync ("Game");
			while (!lol.isDone) {
				progressBar.sizeDelta = new Vector2 (lol.progress * 700, 5);
			
				yield return null;
			}
		} else if (Skills == true) {
			AsyncOperation lol = SceneManager.LoadSceneAsync ("SkillMenu");
			while (!lol.isDone) {
				progressBar.sizeDelta = new Vector2 (lol.progress * 700, 5);

				yield return null;
			}
		} else if (Menu == true) {
			CheckTutorial ();
			if (tut == 0) {
				ChoseLevel ();
				AsyncOperation lol = SceneManager.LoadSceneAsync ("Game");
				while (!lol.isDone) {
					progressBar.sizeDelta = new Vector2 (lol.progress * 700, 5);

					yield return null;
				}
			} else {

				AsyncOperation lol = SceneManager.LoadSceneAsync ("Menu");
				while (!lol.isDone) {
					progressBar.sizeDelta = new Vector2 (lol.progress * 700, 5);

					yield return null;
				}
			}
		}
	}
}
