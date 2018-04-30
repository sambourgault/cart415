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
	bool final = true;
	float timeAsEnd = 0;

	private void Start()
	{

		tankCounter = 0;
		maestroOnce	= true;
		beginingOfEnd = true;
		timeToFade = 0f;

		//numberOfTank = m_Tanks.Length;
		numberOfTank = 10;
		//SpawnAllTanks();

	}

	private void Update(){
		// instantiate tanks
		if (Input.GetMouseButtonDown (0) && violin) {
			float temp = 0;
			if (tankCounter % 2 == 0) {
				temp = 180f;
			}

			if (tankCounter < numberOfTank) {
				m_Tanks [tankCounter].m_Instance =
				Instantiate (m_TankPrefab, new Vector3 (CamPos.transform.position.x + 50, CamPos.transform.position.y + 10, CamPos.transform.position.z + Mathf.Pow (-1, tankCounter) * 20), Quaternion.Euler (180, temp, 0)) as GameObject;
				m_Tanks [tankCounter].Setup ();
				m_Tanks [tankCounter].m_Audio.clip = audios [tankCounter % 5];
				m_Tanks [tankCounter].m_Audio.Play ();

			} else {
				m_Tanks [tankCounter % numberOfTank].SetPosition (new Vector3 (CamPos.transform.position.x + 50, CamPos.transform.position.y + 10, CamPos.transform.position.z + Mathf.Pow (-1, tankCounter) * 20), Quaternion.Euler (180, temp, 0));
				m_Tanks [tankCounter % numberOfTank].SetSpeed ();
			}

			tankCounter++;
		}

		if (lastTank.transform.position.x > 1640) {
			violin = false;
			if (final){
				timeAsEnd = Time.fixedTime;
				final = false;
			}
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


		Debug.Log (Time.fixedTime - timeAsEnd);
		if (!final && (Time.fixedTime - timeAsEnd) > 90f){
			SceneManager.LoadScene ("menu");

		}
	}


		
}
