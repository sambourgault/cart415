using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour {
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene ("menu");
			if (audio != null){
				Destroy (audio);
			}
		}
	}
}
