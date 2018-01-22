﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene1 : MonoBehaviour {
	public Camera m_Camera;
	public GameObject m_Black; 
	//public SceneCounter m_Counter;

	private SpriteRenderer m_BlackRenderer;
	//private int counterScene;


	// Use this for initialization
	void Start () {
		m_BlackRenderer = m_Black.GetComponent<SpriteRenderer> ();
		//Debug.Log ("counter: " + counterScene);
		//counterScene = m_Counter.counter;
	}

	// Update is called once per frame
	void Update () {
		//float newAlpha = Mathf.Lerp (0, 100, Mathf.InverseLerp (0.5f, 60f, m_Camera.fieldOfView));
		//Debug.Log (newAlpha);

		float newAlpha = m_Camera.fieldOfView / 60f;


		m_BlackRenderer.color = new Color(1f, 1f, 1f, newAlpha);

		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene ("tanks_inside3");
		}

		if (m_Camera.fieldOfView <= 0.5f) {
			//m_Counter.counter++;
			//Debug.Log ("counter after increase:" + m_Counter.counter++);
			SceneManager.LoadScene ("tanks_inside3");

			//if (counterScene)
			//counterScene++;
		}
	}
}
