using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class LevelControl : MonoBehaviour {
	public GameObject finalScreen;
	public GameObject endlessMenu;
	public GameObject timeLine;
	public GameObject timeLineGray;
	public Text timeText;
	public GameObject Player;
	public GameObject HPUI;
	public GameObject Tutorial;
	[Header("Enemies")]
	public GameObject Tank;
	public GameObject Zorn;
	public GameObject SpiderRobot;
	public GameObject Boss1;
	[Header("Customize")]
	float timeForMission;
	public float zornSpawnInterval;
	public float tankSpawnInterval;
	public float robotSpawnInterval;
	public float bossSpawnInterval;

	public float zornWhenStartSpawing;
	public float tankWhenStartSpawing;
	public float robotWhenStartSpawing;
	public float bossWhenStartSpawing;


	public int XP;


	public GameObject[] robots; 
	public GameObject[] tank;
	public GameObject[] zorn; 
	public GameObject[] boss;
	bool one;

	void Start () {
		int level = GetComponent<ChoseLoadLevels> ().levelToLoad;
		if (level == 1) {
			timeForMission = 30;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 2;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 25;
			} else {
				XP = 50;
			}
		} else if (level == 2) {
			timeForMission = 40;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 25;
			} else {
				XP = 50;
			}
		} else if (level == 3) {
			timeForMission = 60;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 0.7f;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 75;
			} else {
				XP = 150;
			}
		} else if (level == 4) {
			timeForMission = 90;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1f;
			tankWhenStartSpawing = 5;
			tankSpawnInterval = 30;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 100;
			} else {
				XP = 200;
			}
		} else if (level == 5) {
			timeForMission = 90;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1f;
			tankWhenStartSpawing = 5;
			tankSpawnInterval = 20;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 250;
			} else {
				XP = 500;
			}
		} else if (level == 6) {
			timeForMission = 90;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1f;
			tankWhenStartSpawing = 5;
			tankSpawnInterval = 20;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 350;
			} else {
				XP = 700;
			}
		} else if (level == 7) {
			timeForMission = 120;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1.3f;
			tankWhenStartSpawing = 5;
			tankSpawnInterval = 25;
			robotSpawnInterval = 20;
			robotWhenStartSpawing = 10;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 350;
			} else {
				XP = 700;
			}
		} else if (level == 8) {
			timeForMission = 120;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1f;
			tankWhenStartSpawing = 10;
			tankSpawnInterval = 20;
			robotSpawnInterval = 20;
			robotWhenStartSpawing = 5;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 500;
			} else {
				XP = 1000;
			}
		} else if (level == 9) {
			timeForMission = 130;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1f;
			tankWhenStartSpawing = 10;
			tankSpawnInterval = 20;
			robotSpawnInterval = 20;
			robotWhenStartSpawing = 5;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 750;
			} else {
				XP = 1500;
			}
		} else if (level == 10) {
			timeForMission = 150;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1f;
			tankWhenStartSpawing = 10;
			tankSpawnInterval = 20;
			robotSpawnInterval = 20;
			robotWhenStartSpawing = 10;
			bossSpawnInterval = 30;
			bossWhenStartSpawing = 5;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 1500;
			} else {
				XP = 3000;
			}
		} else if (level == 11) {
			timeForMission = 150;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1.2f;
			tankWhenStartSpawing = 10;
			tankSpawnInterval = 20;
			robotSpawnInterval = 20;
			robotWhenStartSpawing = 20;
			bossSpawnInterval = 15;
			bossWhenStartSpawing = 15;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 1500;
			} else {
				XP = 3000;
			}
		} else if (level == 12) {
			timeForMission = 200;
			zornWhenStartSpawing = 2;
			zornSpawnInterval = 1f;
			tankWhenStartSpawing = 10;
			tankSpawnInterval = 20;
			robotSpawnInterval = 23;
			robotWhenStartSpawing = 20;
			bossSpawnInterval = 15;
			bossWhenStartSpawing = 5;
			if (GetComponent<ChoseLoadLevels> ().maxLevel >= level) {
				XP = 1500;
			} else {
				XP = 3000;
			}
			//BOSS COMING SOON
		} else if (level == 13) {
			endlessMenu.SetActive (true);
			timeLine.SetActive (false);
			timeLineGray.SetActive (false);
			timeText.gameObject.SetActive (false);
			Player.GetComponent<Player> ().endlessModeOn = true; 
			HPUI.SetActive (false);
			//XP = 400;
		} else if (level == 14) {
			
		} else if (level == 15) {
			//TUTORIAL
			timeLine.SetActive (false);
			timeLineGray.SetActive (false);
			timeText.gameObject.SetActive (false);
			Player.GetComponent<Player>().centerGunEnabled = false;
			Player.GetComponent<Player>().doubleGunsEnabled = true;
			Tutorial.SetActive (true);
			timeForMission = 3600;
			StartCoroutine (Tutorial.GetComponent<Tutorial> ().tut ());
		} else if (level == 16) {
			
		} else if (level == 17) {
			
		} else if (level == 18) {
			
		} else if (level == 19) {
			
		} else if (level == 20) {
			
		}



		timeText.color = Color.white;
		timeText.color = Color.white;
		if (level != 13) {
			StartCoroutine (Timer ());
		}

		if (zornSpawnInterval != 0) {
			InvokeRepeating ("SpawnZorn", zornWhenStartSpawing, zornSpawnInterval);
		}
		if (tankSpawnInterval != 0) {
			InvokeRepeating ("SpawnTank", tankWhenStartSpawing, tankSpawnInterval);
		}
		if (robotSpawnInterval != 0) {
			InvokeRepeating ("SpawnSpiderRobot", robotWhenStartSpawing, robotSpawnInterval);
		}
		if (bossSpawnInterval != 0) {
			InvokeRepeating ("SpawnBoss1", bossWhenStartSpawing, bossSpawnInterval);
		}
	}
		

	void SpawnZorn () {
		Instantiate (Zorn, new Vector3 (Random.Range (-1.8f, 1.8f), 7, -0.485f), Quaternion.Euler(90, 180, 0));
	}
	void SpawnTank () {
		Instantiate (Tank, new Vector3 (Random.Range (-1.7f, 1.7f), 7, 0), Quaternion.Euler(90, 0, 180));
	}
	void SpawnSpiderRobot () {
		Instantiate (SpiderRobot, new Vector3 (Random.Range (-1.7f, 1.7f), 5, -0.71f), Quaternion.Euler(100, 90, 270));
	}
	void SpawnBoss1 () {
		Instantiate (Boss1, new Vector3 (0, 7, -1.1f), Quaternion.Euler(90, 180, 0));
	}

	IEnumerator Timer () {
		float timeLeft = timeForMission;
		while (timeLeft > 0) {
			timeLeft-= Time.deltaTime;
			timeLine.GetComponent<RectTransform> ().sizeDelta = new Vector2 (timeLeft * 600 / timeForMission, 5);
			string minSec = string.Format("{0}:{1:00}", (int)timeLeft / 60, (int)timeLeft % 60);
			timeText.text = minSec;
			yield return null;
		}
		timeText.text = "LAST ENEMIES";
		CancelInvoke ();
		robots = GameObject.FindGameObjectsWithTag ("robot");
		tank = GameObject.FindGameObjectsWithTag ("tank");
		zorn = GameObject.FindGameObjectsWithTag ("zorn");
		boss = GameObject.FindGameObjectsWithTag ("BOSS");
		while (zorn.Length !=0 || tank.Length != 0 || robots.Length !=0 || boss.Length != 0) {
			yield return new WaitForSeconds (1);
			robots = GameObject.FindGameObjectsWithTag ("robot");
			tank = GameObject.FindGameObjectsWithTag ("tank");
			zorn = GameObject.FindGameObjectsWithTag ("zorn");
			boss = GameObject.FindGameObjectsWithTag ("BOSS");
		}
		finalScreen.SetActive (true);
		GetComponent<ChoseLoadLevels> ().writeMaxLevel ();
		yield return new WaitForSeconds (1);
		StartCoroutine( Player.GetComponent<XP> ().AddXP (XP));

		Analytics.CustomEvent ("Load Level", new Dictionary<string, object> {
			{ "Which level was loaded", GetComponent<ChoseLoadLevels>().levelToLoad },
			{ "Player's level", Player.GetComponent<XP>().currentLVL },
			{ "Player's experience", Player.GetComponent<XP>().Experience }
		});
	}
}
