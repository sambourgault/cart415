using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource source;
	// Use this for initialization
	void Start () {


	}

	//PLay global
	private static AudioManager instance = null;
	public static AudioManager Instance {
		get { return instance; }
	}
	
	void Awake () {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
		} else {
			instance = this;
		}

		DontDestroyOnLoad (this.gameObject);
	}
}
