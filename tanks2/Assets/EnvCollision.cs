using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvCollision : MonoBehaviour {
	AudioSource audio;
	public Camera cam;
	private float duration = 3.0f; 
	private Color color;
	private Color colorB;

	void Start(){
		audio = GetComponent<AudioSource> ();
		Debug.Log ("audio cactus");
		colorB = Color.black;
	}

	void OnTriggerEnter(Collider other){
		audio.PlayOneShot (audio.clip, 1);
		Debug.Log ("cacctus");

		color.r = Random.Range (0f, 1f);
		color.g = Random.Range (0f, 1f);
		color.b = Random.Range (0f, 1f);
		float t = Mathf.PingPong(Time.time, duration) / duration;
		cam.backgroundColor = Color.Lerp (colorB, color, t);
		colorB = color;
		
	}
}
