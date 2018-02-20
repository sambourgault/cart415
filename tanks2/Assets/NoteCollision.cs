using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollision : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		transform.position = new Vector3 (transform.position.x + 100, transform.position.y, transform.position.z);
	}
}
