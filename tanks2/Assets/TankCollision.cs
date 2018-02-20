using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollision : MonoBehaviour {
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag != "Floor") {
			other.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
