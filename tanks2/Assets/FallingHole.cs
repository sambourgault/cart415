using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FallingHole : MonoBehaviour {
	public AudioSource audio;
	public Image panel;
	

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		audio.volume = Mathf.InverseLerp (-30f, 0f, transform.position.y);
		Debug.Log (audio.volume);
		if (transform.position.y < -2f) {
			panel.CrossFadeAlpha (1f, 2f, true);
		}
		//panel.color.a = Mathf.InverseLerp (-30f, 0f, transform.position.y);

		if (transform.position.y < -30f){
			SceneManager.LoadScene ("tank_market");
			
		}
		
	}
}
