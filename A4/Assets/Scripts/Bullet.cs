using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private float collisionTime = 0.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		rb.velocity = transform.forward * speed;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Special") && Time.time > collisionTime + 1) {
			collisionTime = Time.time;
			collision.gameObject.GetComponent<AudioSource> ().Play ();
			collision.gameObject.GetComponent<ParticleSystem> ().Play ();
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Ammo> ().AddAmmo (AmmoEquipper.activeAmmoType, 10);
			/*
			float xComponent = rb.velocity.x != 0 ? rb.velocity.x / Mathf.Abs (rb.velocity.x) : 0;
			float yComponent = rb.velocity.y != 0 ? rb.velocity.y / Mathf.Abs (rb.velocity.y) : 0;
			float zComponent = rb.velocity.z != 0 ? rb.velocity.z / Mathf.Abs (rb.velocity.z) : 0;
			rb.AddForce (100 * new Vector3 (xComponent, -yComponent, -zComponent));*/
			Vector3 reflected = Vector3.Reflect (rb.velocity, collision.contacts [0].normal);
			//transform.rotation = Quaternion.FromToRotation (rb.velocity, reflected) * transform.rotation;
			rb.velocity = reflected;

		}
		else if (collision.gameObject.CompareTag ("Target")) {
			collision.gameObject.GetComponent<AudioSource> ().Play ();
			collision.gameObject.GetComponentInParent<ParticleSystem> ().Play ();
			Destroy (gameObject);
		}
		else if(!collision.gameObject.CompareTag("Boundary")) {
			Destroy (gameObject);
		}
	}
}
