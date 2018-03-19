using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("blabla");
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Panel"){
			Application.Quit();  
		}
	}
}
