﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerEno : MonoBehaviour {

	public int m_NumRoundsToWin = 5;        
	public float m_StartDelay = 3f;         
	public float m_EndDelay = 3f;           
	public CameraControl m_CameraControl;   
	public Text m_MessageText;              
	public GameObject m_TankPrefab;         
	public TankAiManager[] m_Tanks;   
	public AudioClip[] audios;
	public AudioSource maestro;

	private int m_RoundNumber;              
	private WaitForSeconds m_StartWait;     
	private WaitForSeconds m_EndWait;       
	private TankAiManager m_RoundWinner;
	private TankAiManager m_GameWinner;       
	private float range = 15f;
	private int tankCounter;
	private bool title;
	private bool maestroOnce;
	private bool beginingOfEnd;
	public Image panel;
	private float timeToFade;

	private void Start()
	{
		//m_StartWait = new WaitForSeconds(m_StartDelay);
		//m_EndWait = new WaitForSeconds(m_EndDelay);
		title = true;

		tankCounter = 0;
		maestroOnce	= true;
		beginingOfEnd = true;
		timeToFade = 0f;


		//SpawnAllTanks();

	}

	private void Update(){
		if (Time.frameCount > 150) {
			title = false;
		} 

		if (title) {
			if (maestroOnce && Time.frameCount > 50) {
				maestro.Play ();
				maestroOnce = false;
			}

		} else {
			if (!maestroOnce) {
				m_MessageText.text = string.Empty;
				panel.enabled = false;
				maestroOnce = true;
			}

		

			if (Input.GetMouseButtonDown (0) && tankCounter < 100) {
				m_Tanks [tankCounter].m_Instance =
				Instantiate (m_TankPrefab, m_Tanks [0].m_SpawnPoint.position, m_Tanks [0].m_SpawnPoint.rotation) as GameObject;
				m_Tanks [tankCounter].Setup ();
				m_Tanks [tankCounter].m_Audio.clip = audios [tankCounter % 5];
				m_Tanks [tankCounter].m_Audio.Play ();
				tankCounter++;
			}
		}
			

		if (tankCounter >= 99) {
			if (beginingOfEnd) {
				panel.canvasRenderer.SetAlpha(0.01f);
				//panel.CrossFadeAlpha (0f, 0f, false);
				panel.enabled = true;
				beginingOfEnd = false;
			}

			panel.CrossFadeAlpha (1.0f, 10.0f, false);


			Debug.Log ("alpha decreasing :" + panel.canvasRenderer.GetColor().a);

			if (panel.canvasRenderer.GetColor().a > 0.95f) {
				SceneManager.LoadScene ("tanks_eno3");
			}
		}

	}


	private void SpawnAllTanks()
	{
		
		Debug.Log (audios.Length);
		for (int i = 0; i < audios.Length; i++)
		{
			Debug.Log (i);
			m_Tanks[i].m_Instance =
				Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
			//m_Tanks[i].m_Instance 
			//	= Instantiate(m_TankPrefab, new Vector3(Random.Range(-1*range, range), 0f, Random.Range(-1*range, range)), Quaternion.Euler(Random.Range(0f, 360f), 0f, Random.Range(0f, 360f))) as GameObject;
			m_Tanks[i].Setup();
			m_Tanks [i].m_Audio.clip = audios [i];
			m_Tanks [i].m_Audio.Play ();
		}
	}


	private void SetCameraTargets()
	{
		Transform[] targets = new Transform[m_Tanks.Length];

		for (int i = 0; i < targets.Length; i++)
		{
			targets[i] = m_Tanks[i].m_Instance.transform;
		}

		m_CameraControl.m_Targets = targets;
	}


	private IEnumerator GameLoop()
	{
		// yield means that it is gonna wait before continuing reading the game
		yield return StartCoroutine(RoundStarting());
		yield return StartCoroutine(RoundPlaying());
		yield return StartCoroutine(RoundEnding());

		if (m_GameWinner != null)
		{
			// if there is a winner, load the scene again.
			//SceneManager.LoadScene(0);
			Application.LoadLevel (Application.loadedLevel);
		}
		else
		{
			// no yield here so not waiting
			StartCoroutine(GameLoop());
		}
	}


	/* Reset all tanks --> ask the tankmanager Reset()
	 * Disable all Tanks control --> tankmanager DisableControl()
	 * Set Camera Pos & Size
	 * Increment Round number
	 * Set Message UI
	 */
	private IEnumerator RoundStarting()
	{
		ResetAllTanks ();
		// we want to wait before allowing player to control the tanks
		DisableTankControl ();

		m_CameraControl.SetStartPositionAndSize ();

		m_RoundNumber++;
		//m_MessageText.text = "ROUND " + m_RoundNumber;

		yield return m_StartWait;

	}

	/* Enable all tank controls --> ask TankManager EnableControls();
	 * Empty Message UI
	 * Wait for One Tank Left
	 */
	private IEnumerator RoundPlaying()
	{
		EnableTankControl ();

		//m_MessageText.text = string.Empty;

		while (!OneTankLeft ()) {
			yield return null;
		}
	}

	/* Disable all Tank Controls --> ask TankManager
	 * Clear existing & get round winner
	 * Check for Game Winner
	 * Calculate Message UI & Show
	 */
	private IEnumerator RoundEnding()
	{
		DisableTankControl ();

		m_RoundWinner = null;

		// check in tanks array if one is still active
		m_RoundWinner = GetRoundWinner ();

		if (m_RoundWinner != null){
			m_RoundWinner.m_Wins++;
		}

		// check if one tank has the right number of wins to win
		m_GameWinner = GetGameWinner ();

		// calculating what to write on the screen
		string message = EndMessage ();
		//m_MessageText.text = message;

		yield return m_EndWait;
	}


	private bool OneTankLeft()
	{
		int numTanksLeft = 0;

		for (int i = 0; i < m_Tanks.Length; i++)
		{
			if (m_Tanks[i].m_Instance.activeSelf)
				numTanksLeft++;
		}

		return numTanksLeft <= 1;
	}


	private TankAiManager GetRoundWinner()
	{
		for (int i = 0; i < m_Tanks.Length; i++)
		{
			if (m_Tanks[i].m_Instance.activeSelf)
				return m_Tanks[i];
		}

		return null;
	}


	private TankAiManager GetGameWinner()
	{
		for (int i = 0; i < m_Tanks.Length; i++)
		{
			if (m_Tanks[i].m_Wins == m_NumRoundsToWin)
				return m_Tanks[i];
		}

		return null;
	}


	private string EndMessage()
	{
		string message = "DRAW!";

		if (m_RoundWinner != null)
			message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

		message += "\n\n\n\n";

		for (int i = 0; i < m_Tanks.Length; i++)
		{
			message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
		}

		if (m_GameWinner != null)
			message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

		return message;
	}


	private void ResetAllTanks()
	{
		for (int i = 0; i < m_Tanks.Length; i++)
		{
			m_Tanks[i].Reset();
		}
	}


	private void EnableTankControl()
	{
		for (int i = 0; i < m_Tanks.Length; i++)
		{
			m_Tanks[i].EnableControl();
		}
	}


	private void DisableTankControl()
	{
		for (int i = 0; i < m_Tanks.Length; i++)
		{
			m_Tanks[i].DisableControl();
		}
	}
}
