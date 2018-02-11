using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollision : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		other.GetComponent<AudioSource> ().Play ();
	}
}
