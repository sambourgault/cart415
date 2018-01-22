using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCounter : MonoBehaviour {
	public int counter;

	void Awake(){
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		//counter++;
		Debug.Log ("counter: " + counter);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
