using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public AudioSource source;
	// Use this for initialization
	void Start () {

		/*if (SceneManager.GetActiveScene().name == "menu" ) {

			Destroy (this.gameObject);
		}*/
	}

	void Update(){
		if (SceneManager.GetActiveScene().name == "menu" ) {

			Destroy (this.gameObject);
		}
	
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
