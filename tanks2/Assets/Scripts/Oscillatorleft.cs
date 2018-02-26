using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillatorleft : MonoBehaviour {
	//public double frequency = 440.0;
	//public double startingFreq = 100;
	public AudioClip[] clips;
	public AudioClip fire;
	public AudioSource osc;
	public AudioSource drum;
	public AudioSource charging;


	private double increment;
	private double phase;
	private double sampling_frequency = 48000.0;

	public float gain;
	public float volume = 0.1f;
	public int typeOfWave = 1;

	public double[] frequencies;
	public int thisFreq;

	private int beatCounter;
	private int beat; 
	private string pattern;
	private List<char> patternList;
	private int patternCounter;
	private int barCounter;

	private bool beginVoice;
	private bool beginCharging;

	//public GameObject tanks;

	void Awake(){
		beatCounter = 0;
		beat = 4;
		pattern = "ooxoxooxooxx";
		patternCounter = 0;
		barCounter = 0;
		patternList = new List<char> ();
		for (int i = 0; i < pattern.Length; i++){
			patternList.Add (pattern[i]);
		}

		beginVoice = true;
		beginCharging = false;


		//clips = new AudioClip[2];

		// do - re - re# - fa - sol
		frequencies = new double[5];
		frequencies [0] = 261.626;
		frequencies [1] = 293.665;
		frequencies [2] = 311.127;
		frequencies [3] = 349.228;
		frequencies [4] = 391.995;

	}

	void Start(){

	}

	void Update(){
		gain = volume;	
		beginVoice = true;


		if (transform.position.x > 1407) {
			beginCharging = true;
		}
	}

	void OnTriggerEnter(Collider other){
		// VOICE
		if ( other.gameObject.tag == "Note"){

			GameObject go = other.gameObject;
			go.transform.position = new Vector3(go.transform.position.x + 120, go.transform.position.y , go.transform.position.z );
			beatCounter = beatCounter % beat;
			Debug.Log ("left " + beatCounter);

			if (beginVoice){
				//beatCounter = beatCounter % beat;

				if (patternList [patternCounter] == 'o' && beatCounter < clips.Length) {
					osc.PlayOneShot(clips[beatCounter], 1);


					if (beginCharging) {
						charging.Play ();
					}
				}
			}
			beatCounter++;
		}

		// DRUM
		if (patternList [patternCounter] == 'o' && other.gameObject.tag == "Note") {
			drum.PlayOneShot (fire, 1);
		}
		

		if (other.gameObject.tag == "Note") {
			patternCounter++;
			//Debug.Log (patternCounter);
			if (patternCounter == pattern.Length) {
				barCounter++;

				if (barCounter == 2) {
					Debug.Log ("offset in rhythm");
					//ProcessMusic ();
				}
			}

			patternCounter = patternCounter % pattern.Length;
		
			barCounter = barCounter % 4;
		}
			
	}

	void ProcessMusic(){
		char toMove = patternList [0]; //.GetRange (0, 1);
		patternList.RemoveAt(0);
		patternList.Add (toMove);
		Debug.Log ("Pattern " + patternList[0]+patternList[1]+patternList[2]);
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
