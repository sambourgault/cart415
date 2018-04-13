using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SwitchScene : MonoBehaviour {
	public Camera m_Camera;
	public GameObject m_Black; 
	public Text m_MessageText;  
	public Image panel;

	//public SceneCounter m_Counter;
	private float beginTime = 0f;
	private SpriteRenderer m_BlackRenderer;

	//private int counterScene;


	// Use this for initialization
	void Start () {
		m_BlackRenderer = m_Black.GetComponent<SpriteRenderer> ();
		beginTime = Time.frameCount;
		//Debug.Log ("counter: " + counterScene);
		//counterScene = m_Counter.counter;
	}

	// Update is called once per frame
	void Update () {
		//float newAlpha = Mathf.Lerp (0, 100, Mathf.InverseLerp (0.5f, 60f, m_Camera.fieldOfView));
		//Debug.Log (newAlpha);
		if ((Time.frameCount - beginTime) > 210) {

			float newAlpha = m_Camera.fieldOfView / 60f;


			m_BlackRenderer.color = new Color (1f, 1f, 1f, newAlpha);

			if (m_Camera.fieldOfView <= 0.5f) {
				SceneManager.LoadScene ("tanks_inside2");

			}
		} else if ((Time.frameCount - beginTime) > 200 ) {
			m_MessageText.text = string.Empty;
		} else if ((Time.frameCount - beginTime) > 0) {
			panel.enabled = false;
			m_MessageText.text = "the inside";
		} 
	}
}
