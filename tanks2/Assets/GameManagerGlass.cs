using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerGlass : MonoBehaviour {

	public Text m_MessageText;              
	//public AudioClip[] audios;
	public AudioSource maestro;
	public GameObject[] m_TankPrefab;         

	public TankAiManager[] m_Tanks;   

	private bool title;
	private bool maestroOnce;
	public Image panel;
	private int tankCounter;
	private int timeAtStart;


	// Use this for initialization
	void Start () {

		timeAtStart = Time.frameCount;

		title = true;

//		tankCounter = 0;
		maestroOnce	= true;
		tankCounter = 0;

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount > 150 + timeAtStart) {
			title = false;
		} 

		if (title) {
			if (maestroOnce && Time.frameCount > 50 + timeAtStart) {
				maestro.Play ();
				maestroOnce = false;
			}

		} else {
			m_MessageText.text = string.Empty;
			panel.enabled = false;

			if (Input.GetMouseButtonDown (0) && tankCounter < 2) {
				m_TankPrefab [tankCounter].active = true;
				/*m_Tanks [tankCounter].m_Instance =
					Instantiate (m_TankPrefab[tankCounter], new Vector3(-441f, 0f , -5.3f + tankCounter*10.6f), Quaternion.Euler(0f, 90f, 0f) ) as GameObject;
				m_Tanks [tankCounter].Setup ();*/
				//m_Tanks [tankCounter].m_Audio.clip = audios [tankCounter % 5];
				//m_Tanks [tankCounter].m_Audio.Play ();
				tankCounter++;
			}

			if (tankCounter == 2) {
				for (int i = 0; i < m_TankPrefab.Length; i++){
					m_TankPrefab[i].GetComponent<TankMovement1> ().enabled = true;
				}
			}

		}

	}
}
