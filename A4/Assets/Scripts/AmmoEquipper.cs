using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoEquipper : MonoBehaviour {

	public static string activeAmmoType;
	public GameObject cubeBullet;
	public GameObject sphereBullet;
	public GameObject cylinderBullet;

	private GameObject activeAmmo;

	// Use this for initialization
	void Start () {
		activeAmmoType = "cube";
		activeAmmo = cubeBullet;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			activeAmmoType = "cube";
			activeAmmo = cubeBullet;
		}
		else if (Input.GetKeyDown ("2")) {
			activeAmmoType = "sphere";
			activeAmmo = sphereBullet;
		}
		else if (Input.GetKeyDown ("3")) {
			activeAmmoType = "cylinder";
			activeAmmo = cylinderBullet;
		}
	}

	public GameObject GetActiveAmmo() {
		return activeAmmo;
	}
}
