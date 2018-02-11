using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mphone : MonoBehaviour {

	public AudioSource audiosource;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();

		// the boolean is for the loop option
	
		/*foreach (string device in Microphone.devices){
			Debug.Log (device);
		}*/
		UpdateMicrophone ();
	}

	void UpdateMicrophone(){
		audiosource.Stop ();
		audiosource.clip = Microphone.Start("Built-in Input", true, 10, 44100);
		audiosource.loop = true;
	
		if (Microphone.IsRecording("Built-in Input")){
			audiosource.Play ();
		}
	}

}
