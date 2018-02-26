using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerGlass : MonoBehaviour {

	public Text m_MessageText;              
	public AudioClip[] audios;
	public AudioSource maestro;
	public GameObject[] m_TankPrefab;         
	public TankAiManager[] m_Tanks;   

	private bool title;
	private bool maestroOnce;
	public Image panel;
	private int tankCounter;


	// Use this for initialization
	void Start () {

		title = true;

//		tankCounter = 0;
		maestroOnce	= true;
		tankCounter = 0;

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount > 150) {
			title = false;
		} 

		if (title) {
			if (maestroOnce && Time.frameCount > 50) {
				maestro.Play ();
				maestroOnce = false;
			}

		} else {
			m_MessageText.text = string.Empty;
			panel.enabled = false;

			if (Input.GetMouseButtonDown (0) && tankCounter < 2) {
				m_Tanks [tankCounter].m_Instance =
					Instantiate (m_TankPrefab[tankCounter], new Vector3(-441, 0 , -5.3 + tankCounter*10.6), new Vector3(0, 90, 0) ) as GameObject;
				m_Tanks [tankCounter].Setup ();
				m_Tanks [tankCounter].m_Audio.clip = audios [tankCounter % 5];
				m_Tanks [tankCounter].m_Audio.Play ();
				tankCounter++;
			}

		}
		
	}
}
