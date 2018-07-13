using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Transform firePosition;
	public float fireRate;
	private float lastFireTime;
	public Ammo ammo;
	public AudioClip liveFire;
	public AudioClip dryFire;
	private AmmoEquipper equipper;

	// Use this for initialization
	void Start () {
		equipper = GetComponentInParent<AmmoEquipper> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && (Time.time - lastFireTime) > fireRate) {
			lastFireTime = Time.time;
			Fire ();
		}
	}
	
	protected void Fire() {
		if (ammo.HasAmmo (AmmoEquipper.activeAmmoType)) {
			GetComponent<AudioSource> ().PlayOneShot (liveFire);
			ammo.ConsumeAmmo (AmmoEquipper.activeAmmoType);

			GameObject bullet = Instantiate(equipper.GetActiveAmmo());
			bullet.transform.position = firePosition.position;
			bullet.transform.rotation = firePosition.rotation;
			
		}
		else {
			GetComponent<AudioSource> ().PlayOneShot (dryFire);
		}

		GetComponentInChildren<Animator> ().Play ("Fire");
	}
}
