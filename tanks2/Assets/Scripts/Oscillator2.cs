using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator2 : MonoBehaviour {
	//public double frequency = 440.0;
	//public double startingFreq = 100;
	public AudioClip[] clips;
	public AudioSource osc;

	private double increment;
	private double phase;
	private double sampling_frequency = 48000.0;
	//private AudioSource audio;


	public float gain;
	public float volume = 0.05f;
	public int typeOfWave = 0;

	public double[] frequencies;
	public int thisFreq;

	private int beatCounter;
	private int beat; 
	//public GameObject tanks;

	void Awake(){
		beatCounter = 0;
		beat = 5;

		//clips = new AudioClip[2];

		// do - re - re# - fa - sol
		frequencies = new double[5];
		frequencies [0] = 261.626;
		frequencies [1] = 293.665;
		frequencies [2] = 311.127;
		frequencies [3] = 349.228;
		frequencies [4] = 391.995;

		//osc = GetComponent<AudioSource>();

		// do - fa - sol - la# - do
		// do - re - re# - fa - sol
	
	
	}

	void Start(){
		//audio = GetComponent<AudioSource> ();
		//audio.Play ();
		//osc.Play();



	}

	void Update(){
		//if (Input.GetKeyDown(KeyCode.Space)){
		gain = volume;	
		//frequency = startingFreq + Random.Range();
		//frequency = transform.rotation.eulerAngles.y/360f * 150f + 100f;
		//osc.panStereo = Mathf.Lerp (-1f, 1f, Mathf.InverseLerp (-20f, 20f, transform.position.x));
		//frequency = frequencies [thisFreq];
		//thisFreq += 1;
		//thisFreq = thisFreq % frequencies.Length;
		//}
		/*if (Time.frameCount % 200 == 0) {
			int beat = (int)Random.Range (1f, 5f);
			Debug.Log ("beeeat change: " + beat);
			beatCounter = beat - 1;
		}*/


		if (Input.GetKeyUp(KeyCode.Space)){
			gain = 0;
		}

	}

	void OnTriggerEnter(Collider other){
		//Debug.Log ("collision with note");

		if (other.gameObject.tag == "Note"){
			GameObject go = other.gameObject;
			go.transform.position = new Vector3(go.transform.position.x + 80, go.transform.position.y , go.transform.position.z );
			//other.collider.enabled = false;
			beatCounter = (beatCounter + 1) % beat;
			//Debug.Log ("collision with note");

			if (beatCounter < clips.Length) {
				osc.PlayOneShot(clips[beatCounter], 1);
			}
		}
		//voice.Play ();
	
	}

	/*void OnAudioFilterRead(float[] data, int channels){
		increment = frequencies[beatCounter] * 2.0 * Mathf.PI / sampling_frequency;

		for (int i = 0; i < data.Length; i += channels) {
			phase += increment;

			if (typeOfWave == 0) {
				// sin wave
				data [i] = (float)(gain * Mathf.Sin ((float)phase));
			} else if (typeOfWave == 1) {
				// sqrt wave
				if (gain * Mathf.Sin ((float)phase) >= 0 * gain) {
					data [i] = (float)gain * 0.6f;
				} else {
					data [i] = (-(float)gain) * 0.6f;
				}
			} else if (typeOfWave == 2) {
				// tri wave
				data[i] = (float) (gain * (double)Mathf.PingPong((float) phase, 1.0f));
			}

			if (channels == 2) {
				data [i + 1] = data [i];
			}

			if (phase > (Mathf.PI * 2)) {
				phase = 0.0;
			}
				
		}

	}*/
}
