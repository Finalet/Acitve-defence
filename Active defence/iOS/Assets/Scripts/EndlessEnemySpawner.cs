using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessEnemySpawner : MonoBehaviour {
	[Header("Enemies")]
	public GameObject Tank;
	public GameObject Zorn;
	public GameObject SpiderRobot;
	public GameObject Boss1;

	[Space]
	public float zornSpawnInterval;
	public float tankSpawnInterval;
	public float robotSpawnInterval;
	public float bossSpawnInterval;

	public float zornWhenStartSpawing;
	public float tankWhenStartSpawing;
	public float robotWhenStartSpawing;
	public float bossWhenStartSpawing;

	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
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
}
