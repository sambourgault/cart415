using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene_traffic : MonoBehaviour {
	//public Camera m_Camera;
	//public GameObject m_Black; 
	//public SceneCounter m_Counter;
	public Text m_MessageText;

	private float initialFrame;

	//private SpriteRenderer m_BlackRenderer;
	//private int counterScene;


	// Use this for initialization
	void Start () {
		initialFrame = Time.fixedTime;
	}

	// Update is called once per frame
	void Update () {

		if ((Time.fixedTime- initialFrame)  > 4f){
			m_MessageText.text = string.Empty;
		}

		// load new scene after a certain amount of frames
		if ((Time.fixedTime - initialFrame)  > 75f) {
			SceneManager.LoadScene ("tanks_god");
		}

	}
}
