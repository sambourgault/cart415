using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
	public double frequency = 440.0;
	public double startingFreq = 100;
	private double increment;
	private double phase;
	private double sampling_frequency = 48000.0;

	public float gain;
	public float volume = 0.1f;
	public int typeOfWave = 0;

	public float[] frequencies;
	public int thisFreq;
	public GameObject tanks;

	void Start(){
		
		/*frequencies = new float[5];
		frequencies [0] = 110;
		frequencies [1] = 220;
		frequencies [2] = 330;
		frequencies [3] = 440;
		frequencies [4] = 550;*/

	}

	void Update(){
		//if (Input.GetKeyDown(KeyCode.Space)){
			gain = volume;	
			frequency = tanks.transform.rotation.eulerAngles.y/360f * 150f + 100f;
			//frequency = frequencies [thisFreq];
			//thisFreq += 1;
			//thisFreq = thisFreq % frequencies.Length;
		//}

		if (Input.GetKeyUp(KeyCode.Space)){
			gain = 0;

		}

	}

	void OnAudioFilterRead(float[] data, int channels){
		increment = startingFreq * 2.0 * Mathf.PI / sampling_frequency;

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
	
	}

}
