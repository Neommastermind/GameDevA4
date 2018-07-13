using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

	[SerializeField]
	private int cubeAmmo = 20;
	[SerializeField]
	private int sphereAmmo = 10;
	[SerializeField]
	private int cylinderAmmo = 50;
	public Dictionary<string, int> tagToAmmo;

	void Awake() {
		tagToAmmo = new Dictionary<string, int> {
			{"cube", cubeAmmo},
			{"sphere", sphereAmmo},
			{"cylinder", cylinderAmmo}
		};
	}

	public void AddAmmo(string tag, int ammo) {
		if (!tagToAmmo.ContainsKey (tag)) {
			Debug.LogError ("Unrecognized gun type passed: " + tag);
		}
		tagToAmmo[tag] += ammo;
	}

	public bool HasAmmo(string tag) {
		if (!tagToAmmo.ContainsKey (tag)) {
			Debug.LogError ("Unrecognized gun type passed: " + tag);
		}
		return tagToAmmo[tag] > 0;
	}

	public int GetAmmo(string tag) {
		if (!tagToAmmo.ContainsKey (tag)) {
			Debug.LogError ("Unrecognized gun type passed: " + tag);
		}
		return tagToAmmo[tag];
	}

	public void ConsumeAmmo(string tag) {
		if (!tagToAmmo.ContainsKey (tag)) {
			Debug.LogError ("Unrecognized gun type passed: " + tag);
		}
		tagToAmmo[tag]--;
	}
}
