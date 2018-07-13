using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

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
		if(collision.gameObject.CompareTag("Target")) {
			collision.gameObject.GetComponent<AudioSource> ().Play ();
		}

		Destroy (gameObject);
	}
}
