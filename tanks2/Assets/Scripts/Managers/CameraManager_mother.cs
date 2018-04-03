using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CameraManager_mother : MonoBehaviour {

	public Camera mainCam;
	public Text m_MessageText;
	public Image panel;

	private GameObject[] cameras;
	private int currentCam;
	private int nextCam;
	private bool switchScene = false;

	private int initialFrame;

	// Use this for initialization
	void Awake() {
		mainCam.GetComponent<Camera> ().enabled = false;
		cameras = GameObject.FindGameObjectsWithTag ("Camera");
		Debug.Log (cameras.Length);
		//Debug.Log (cameras [0]);
		for(int i = 0; i < cameras.Length; i++){
			if (i != 0) {
				cameras [i].GetComponent<Camera> ().enabled = false;
			}

		}
		//mainCam.GetComponent<Camera> ().enabled = false;
		//cameras [0].GetComponent<Camera> ().enabled = true;
		currentCam = 0;
		nextCam = 1;
		
	}

	void Start(){
		initialFrame = Time.frameCount;

	}

	// Update is called once per frame
	void Update () {
		if ((Time.frameCount - initialFrame) > 200){
			m_MessageText.text = string.Empty;
			panel.enabled = false;
		}

		if (Time.frameCount % 200 == 0 && (Time.frameCount- initialFrame)  > 201) {
			
			if (switchScene){
				//load scene after the last camera
				SceneManager.LoadScene ("tanks_traffic");
			} else if (currentCam == cameras.Length) {
				cameras [nextCam].GetComponent<Camera> ().enabled = true;
				mainCam.enabled = false;

				currentCam = 0;
				nextCam = 1;
			} else if (currentCam == cameras.Length - 1) {
				mainCam.enabled = true;
				cameras [currentCam].GetComponent<Camera> ().enabled = false;
				switchScene = true;
				currentCam = cameras.Length;
				nextCam = 0;
			} else {
				cameras [nextCam].GetComponent<Camera> ().enabled = true;
				cameras [currentCam].GetComponent<Camera> ().enabled = false;

				currentCam++;
				nextCam++;
			}
		}
		
	}
}
