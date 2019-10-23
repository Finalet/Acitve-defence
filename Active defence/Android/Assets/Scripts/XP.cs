using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class XP : MonoBehaviour {
	public int LVL;
	public int currentLVL;
	public int Experience;
	public int skillPointNumber;
	public Text skillPointText;

	public Text lvlText;
	public Text otherLvlText;
	public Text xpText;
	public Text xpToNextLvlText;

	public Text currentLvlText;
	public Text currentLvlPlusOneText;

	public Image lvlImage;

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

	void CheckXP () {
		string path = pathForDocumentsFile ("XP.fin");
		if (File.Exists (path)) {
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			Experience = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			Experience = 0;
		}
	}
	public void writeXP () {
		string path = pathForDocumentsFile ("XP.fin");
		FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		StreamWriter sw = new StreamWriter (file);
		sw.WriteLine (Experience);
		sw.Close ();
		file.Close ();
	}

	void CheckSP () {
		string path = pathForDocumentsFile ("SP.fin");
		if (File.Exists (path)) {
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			skillPointNumber = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			skillPointNumber = 0;
		}
	}
	public void writeSP () {
		string path = pathForDocumentsFile ("SP.fin");
		FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		StreamWriter sw = new StreamWriter (file);
		sw.WriteLine (skillPointNumber);
		sw.Close ();
		file.Close ();
	}

	public void AddSP () {
		skillPointNumber++;
		writeSP ();
	}
	public void RemoveSP () {
		skillPointNumber--;
		writeSP ();
	}

	void Start () {
		checkLVL ();
		CheckXP ();
		CheckSP ();
	}
	public IEnumerator AddXP (int x) {
		int y = x;
		while (y > 0) {
			Experience += 12;
			y -= 12;
			yield return new WaitForSeconds (x/5000);
		}
		writeXP ();
		Camera.main.GetComponent<LeaderboardAndroid> ().OnAddScoreToLeaderBorad (Experience);
	}    

	void writeLVL () {
		string path = pathForDocumentsFile ("LVL.fin");
		FileStream file = new FileStream (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
		StreamWriter sw = new StreamWriter (file);
		sw.WriteLine (LVL);
		sw.Close ();
		file.Close ();
	}
	void checkLVL () {
		string path = pathForDocumentsFile ("LVL.fin");
		if (File.Exists (path)) {
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader (file);
			currentLVL = System.Convert.ToInt32 (sr.ReadLine ());
			LVL = System.Convert.ToInt32 (sr.ReadLine ());
			sr.Close ();
			file.Close ();
		} else {
			currentLVL = 1;
			LVL = 1;
		}
	}

	void Update () {
		lvlText.text = "LEVEL: " + currentLVL;
		otherLvlText.text = "" + currentLVL;
		skillPointText.text = "SKILL POINTS: " + skillPointNumber;
		xpText.text = "XP total: " + Experience;


		if (currentLVL <= 29) {
			currentLvlText.text = "" + currentLVL;
			currentLvlPlusOneText.text = "" + (currentLVL + 1);
		} else {
			currentLvlText.text = "30";
			currentLvlPlusOneText.text = "30";
		}


		if (Experience >= 117000) {
			LVL = 30;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 (584, 40);
			xpToNextLvlText.text = "MAX LVL";
		} else if (Experience >= 112000) {
			LVL = 29;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-112000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (117000 - Experience);
		} else if (Experience >= 107000) {
			LVL = 28;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-107000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (112000 - Experience);
		} else if (Experience >= 102000) {
			LVL = 27;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-102000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (105000 - Experience);
		} else if (Experience >= 97000) {
			LVL = 26;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-97000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (102000 - Experience);
		} else if (Experience >= 92000) {
			LVL = 25;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-92000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (97000 - Experience);
		} else if (Experience >= 87000) {
			LVL = 24;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-87000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (92000 - Experience);
		} else if (Experience >= 82000) {
			LVL = 23;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-82000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (87000 - Experience);
		} else if (Experience >= 77000) {
			LVL = 22;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-77000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (82000 - Experience);
		} else if (Experience >= 72000) {
			LVL = 21;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-72000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (77000 - Experience);
		} else if (Experience >= 67000) {
			LVL = 20;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-67000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (72000 - Experience);
		} else if (Experience >= 62000) {
			LVL = 19;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-62000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (67000 - Experience);
		} else if (Experience >= 57000) {
			LVL = 18;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-57000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (62000 - Experience);
		} else if (Experience >= 52000) {
			LVL = 17;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-52000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (57000 - Experience);
		} else if (Experience >= 47000) {
			LVL = 16;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-47000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (52000 - Experience);
		} else if (Experience >= 42000) {
			LVL = 15;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-42000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (47000 - Experience);
		} else if (Experience >= 37000) {
			LVL = 14;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-37000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (42000 - Experience);
		} else if (Experience >= 32000) {
			LVL = 13;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-32000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (37000 - Experience);
		} else if (Experience >= 27000) {
			LVL = 12;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-27000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (32000 - Experience);
		} else if (Experience >= 22000) {
			LVL = 11;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-22000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (27000 - Experience);
		} else if (Experience >= 17000) {
			LVL = 10;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-17000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (22000 - Experience);
		} else if (Experience >= 12000) {
			LVL = 9;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-12000) * 584 / 5000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (17000 - Experience);
		} else if (Experience >= 7850) {
			LVL = 8;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-7850) * 584 / 4150, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (12000 - Experience);
		} else if (Experience >= 4850) {
			LVL = 7;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-4850) * 584 / 3000, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (7850 - Experience);
		} else if (Experience >= 3350) {
			LVL = 6;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-3350) * 584 / 1500, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (4850 - Experience);
		} else if (Experience >= 1650) {
			LVL = 5;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-1650) * 584 / 1700, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (3350 - Experience);
		} else if (Experience >= 950) {
			LVL = 4;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-950) * 584 / 700, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (1650 - Experience);
		} else if (Experience >= 250) {
			LVL = 3;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-250) * 584 / 700, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (950 - Experience);
		} else if (Experience >= 100) {
			LVL = 2;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 ((Experience-100) * 584 / 150, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (250 - Experience);
		} else if (Experience >= 0) {
			LVL = 1;
			lvlImage.GetComponent<RectTransform> ().sizeDelta = new Vector2 (Experience * 584 / 100, 40);
			xpToNextLvlText.text = "XP to next LVL: " + (100 - Experience);
		}

		if (currentLVL != LVL && LVL <= 8) {
			AddSP ();
			writeLVL ();
			checkLVL ();
			writeXP ();
		} else if (LVL > 8) {
			writeLVL ();
			checkLVL ();
			writeXP ();
		}
	}
}
