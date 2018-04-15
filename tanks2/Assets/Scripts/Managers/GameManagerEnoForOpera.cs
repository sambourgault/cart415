using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerEnoForOpera : MonoBehaviour {

	public GameObject CamPos; 
	public GameObject lastTank;
	public GameObject m_TankPrefab;         
	public TankAiManager[] m_Tanks; 
	private int numberOfTank;
	public AudioClip[] audios;
	public AudioSource maestro;
	public bool violin = false;
	public Text textViolin;

	private float range = 15f;
	private int tankCounter;
	private bool title;
	private bool maestroOnce;
	private bool beginingOfEnd;
	private float timeToFade;
	float countInput = 0;


	private void Start()
	{

		tankCounter = 0;
		maestroOnce	= true;
		beginingOfEnd = true;
		timeToFade = 0f;

		numberOfTank = m_Tanks.Length;
		//SpawnAllTanks();

	}

	private void Update(){
		// instantiate tanks
		if (Input.GetMouseButtonDown (0) && tankCounter < 40 && violin) {
			float temp = 0;
			if (tankCounter % 2 == 0) {
				temp = 180f;
			}

			if (tankCounter < numberOfTank){
			m_Tanks [tankCounter].m_Instance =
				Instantiate (m_TankPrefab, new Vector3 (CamPos.transform.position.x + 50, CamPos.transform.position.y + 10, CamPos.transform.position.z + Mathf.Pow (-1, tankCounter) * 20), Quaternion.Euler (180, temp, 0)) as GameObject;
			}
			m_Tanks [tankCounter % numberOfTank].Setup ();
			m_Tanks [tankCounter % numberOfTank].m_Audio.clip = audios [tankCounter % 5];
			m_Tanks [tankCounter % numberOfTank].m_Audio.Play ();
			tankCounter++;
		}

		if (lastTank.transform.position.x > 1645) {
			violin = false;
		} else if (lastTank.transform.position.x > 1290) {
			violin = true;
		} else if (lastTank.transform.position.x > 800) {
			violin = false;
		} else if (lastTank.transform.position.x > 350){
			violin = true;
		} else if (lastTank.transform.position.x > -400) {
			violin = false;
		} else if (lastTank.activeSelf){
			violin = true;
		}

		if (violin) {
			textViolin.enabled = true;
		} else {
			textViolin.enabled = false;
		}

	}


		
}
