using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	//СДЕЛАТЬ more games МЕНЮ
	private Vector3 pos;
	public bool endlessModeOn;
	public GameObject endlessMenu;
	[Header("Characteristics")]
	public int castleHP; 
	public float RocketsCoolDownTime;
	public float FlamethrowerCoolDownTime;
	public float beamCoolDownTime;
	bool CanFlameThrow = true;
	bool CanBeam = true;

	public float shootingSpeed;
	public int projectileSpeed;

	[Header("Upgrades")]
	public bool centerGunEnabled;
	public bool doubleGunsEnabled;
	public bool rocketsEnabled;
	public bool flamethrowerEnabled;
	public bool beamEnabled;

	[Header("Game Objects")]
	public GameObject projectile;
	public GameObject fullProjectile;
	public GameObject emptyProjectile;
	public GameObject leftProjectileSpawn;
	public GameObject rightProjectileSpawn;
	public GameObject centerProjectileSpawn;

	[Header("Upgrades GameObjects")]
	public GameObject centerGun;
	public GameObject leftGun;
	public GameObject rightGun;
	public GameObject rockets;
	public GameObject flamethrower;
	public GameObject flamethrowerGhost;
	public GameObject beam;

	[Header("Rockets of all sorts")]
	public GameObject target;
	public GameObject targetUI;
	public GameObject targetBUTTON;
	public GameObject leftReal;
	public GameObject leftFake;
	public GameObject rightReal;
	public GameObject rightFake;

	[Header("UI")]
	public GameObject coolDownUI1;
	public GameObject coolDownUI2;
	public GameObject coolDownUI3;
	public GameObject flamethrowerUI;
	public GameObject beamUI;
	public GameObject HP;
	public GameObject loseScreen;

	[Header("Materials")]
	public Material Cyan;
	public Material Red;
	public GameObject centerMat;
	public GameObject leftMat;
	public GameObject rightMat;

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

	void Awake () {
		projectile = fullProjectile;

		CheckDoubleGuns ();
		CheckTripleGuns ();
		CheckRocketsGuns ();
		CheckBeamGuns ();
		CheckFlamethrowerGuns ();
		CheckTwoDotsGuns ();
		CheckThreeDotsGuns ();

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
			shootingSpeed = 1;
		} else if (twoDotsINT == 1 && threeDotsINT != 1) {
			shootingSpeed = 1.5f;
		} else if (twoDotsINT == 1 && threeDotsINT == 1) {
			shootingSpeed = 3f;
		}
	}
		
	void Start () {
		if (Camera.main.GetComponent<ChoseLoadLevels> ().levelToLoad == 15) {
			InvokeRepeating ("Shoot", 0, 0.35f);

		} else {
			InvokeRepeating ("Shoot", 0, 1 / shootingSpeed);
		}
	}

	void Update () {
		if (targetUI.activeInHierarchy == true) {
			targetUI.transform.Rotate (targetUI.transform.forward * Time.deltaTime * 50);
		}
		if (flamethrowerEnabled == true) {
			flamethrowerUI.SetActive (true);
		} else {
			flamethrowerUI.SetActive (false);
		}
		if (beamEnabled == true) {
			beamUI.SetActive (true);
			centerMat.GetComponent<MeshRenderer> ().material = Red;
			leftMat.GetComponent<MeshRenderer> ().material = Red;
			rightMat.GetComponent<MeshRenderer> ().material = Red;
		} else{
			beamUI.SetActive (false);
			centerMat.GetComponent<MeshRenderer> ().material = Cyan;
			leftMat.GetComponent<MeshRenderer> ().material = Cyan;
			rightMat.GetComponent<MeshRenderer> ().material = Cyan;
		}

		if (Input.touchCount > 0 && GetComponent<Pause>().isPaused == false) {
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 5));
		}
		if (targetUI.activeInHierarchy == false && endlessMenu.activeInHierarchy == false){
			transform.position = new Vector3 (pos.x, transform.position.y, transform.position.z);
		}

		if (doubleGunsEnabled == true) {
			leftGun.SetActive (true);
			rightGun.SetActive (true);
		} else {
			leftGun.SetActive (false);
			rightGun.SetActive (false);
		}
		if (centerGunEnabled == true) {
			centerGun.SetActive (true);
		} else {
			centerGun.SetActive (false);
		}
		if (rocketsEnabled == true) {
			rockets.SetActive (true);
			targetBUTTON.SetActive (true);
		} else {
			rockets.SetActive (false);
			targetBUTTON.SetActive (false);
		}


		// MOUSE CONTROLLS FOR DEBUG ONLY

		if(Input.GetMouseButton(0) && GetComponent<Pause>().isPaused == false){
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 5));
		}

		// MOUSE CONTROLLS OVER

		CheckHP ();

		if(Input.GetKeyDown (KeyCode.Space) && leftFake.activeInHierarchy == true && rightFake.activeInHierarchy == true) {
			FireRockets ();
		}
		if (leftReal.activeInHierarchy == false) {
			leftReal.transform.position = leftFake.transform.position;
		}
		if (rightReal.activeInHierarchy == false) {
			rightReal.transform.position = rightFake.transform.position;
		}

	}

	void CheckHP () {
		if (castleHP <= 0) {
			if (endlessModeOn == false) {
				Death ();
			}
		}

		if (endlessModeOn == false) {
			HP.GetComponent<RectTransform> ().sizeDelta = new Vector2 (15, castleHP * 562 / 2000);
		}
	}
	void Death (){
		loseScreen.SetActive (true);
		Camera.main.GetComponent<LevelControl> ().CancelInvoke ();
		CancelInvoke ();
	}

	void Shoot () {
		GetComponent<Animation> ().Play ("recoil");
		if (leftGun.activeInHierarchy == true) {
			Instantiate (projectile, leftProjectileSpawn.gameObject.transform.position, Quaternion.identity);
		} 
		if (rightGun.activeInHierarchy == true) {
			Instantiate (projectile, rightProjectileSpawn.gameObject.transform.position, Quaternion.identity);
		}
		if (centerGun.activeInHierarchy == true) {
			Instantiate (projectile, centerProjectileSpawn.gameObject.transform.position, Quaternion.identity);
		}
	}


	IEnumerator Shake () {
		
		float elapsed = 0.0f;

		Vector3 originalCamPos = Camera.main.transform.position;

		while (elapsed < 0.7f) {

			elapsed += Time.deltaTime;          

			float percentComplete = elapsed / 0.7f;         
			float damper = 1.0f - Mathf.Clamp (4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= 0.2f * damper;
			y *= 0.2f * damper;

			Camera.main.transform.position = new Vector3 (x, y - 0.8f, originalCamPos.z);

			yield return null;
		}

		Camera.main.transform.position = originalCamPos;
	}


	void FireRockets () {
		leftFake.SetActive (false);
		rightFake.SetActive (false);
		leftReal.SetActive (true);
		rightReal.SetActive (true);
		StartCoroutine (RocketsCoolDown ());
	}
	public void BeginDrag () {
		if (leftFake.activeInHierarchy == true) {
			targetUI.SetActive (true);
			target.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 7.4f));
		}

	}
	public void EndDrag () {
		if (leftFake.activeInHierarchy == true) {
			targetUI.SetActive (false);
			FireRockets ();
		}
	}

	IEnumerator RocketsCoolDown () {
		float TimeLeft = RocketsCoolDownTime;
		while (TimeLeft > 0) {
			TimeLeft -= Time.deltaTime;
			coolDownUI1.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, TimeLeft * 100 / RocketsCoolDownTime);
			yield return null;
		}
		leftFake.SetActive (true);
		rightFake.SetActive (true);
	}


	public void FlamethrowerDrag () {
		if (CanFlameThrow == true) {
			flamethrowerGhost.SetActive (true);
			flamethrower.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 1.1f, Input.mousePosition.y, 7.3f));
			flamethrowerGhost.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width-100, Input.mousePosition.y,7.3f));
		}
	}

	public void FlamethrowerVoid () {
		if (CanFlameThrow == true) {
		flamethrowerGhost.SetActive (false);
		StartCoroutine (FlamethrowerLOL ());
		StartCoroutine (FlamethrowerCoolDown ());
		CanFlameThrow = false;
		}
	}

	IEnumerator FlamethrowerLOL () {
		flamethrower.SetActive (true);
		yield return new WaitForSeconds (10);
		flamethrower.SetActive (false);
	}

	IEnumerator FlamethrowerCoolDown () {
		float TimeLeft = FlamethrowerCoolDownTime;
		while (TimeLeft > 0) {
			TimeLeft -= Time.deltaTime;
			coolDownUI2.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, TimeLeft * 100 / FlamethrowerCoolDownTime);
			yield return null;
		}
		CanFlameThrow = true;
	}

	public void Beam () {
		if (CanBeam == true){
			StartCoroutine (BEAMIE ());
			StartCoroutine (BeamCoolDown ());
			CanBeam = false;
		}
	}

	IEnumerator BEAMIE () {
		beam.SetActive (true);
		projectile = emptyProjectile;
		yield return new WaitForSeconds (5);
		projectile = fullProjectile;
		beam.SetActive(false);
	}

	IEnumerator BeamCoolDown () {
		float TimeLeft = beamCoolDownTime;
		while (TimeLeft > 0) {
			TimeLeft -= Time.deltaTime;
			coolDownUI3.GetComponent<RectTransform> ().sizeDelta = new Vector2 (100, TimeLeft * 100 / beamCoolDownTime);
			yield return null;
		}
		CanBeam = true;
	}
}
