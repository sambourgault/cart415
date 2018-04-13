using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene1 : MonoBehaviour {
	public Camera m_Camera;
	public GameObject m_Black; 
	public GameObject m_CactusPrefab;     
	//public SceneCounter m_Counter;
	//[HideInInspector] public GameObject[] m_Instance;  
	private int counterCactus = 0;
	public GameObject[] cactus;

	private SpriteRenderer m_BlackRenderer;
	private float initialFOV;
	//private int counterScene;


	// Use this for initialization
	void Start () {
		m_BlackRenderer = m_Black.GetComponent<SpriteRenderer> ();
		initialFOV = m_Camera.fieldOfView;
		//m_Instance = new GameObject[20];
		//Debug.Log ("counter: " + counterScene);
		//counterScene = m_Counter.counter;
	}

	// Update is called once per frame
	void Update () {
		//float newAlpha = Mathf.Lerp (0, 100, Mathf.InverseLerp (0.5f, 60f, m_Camera.fieldOfView));
		//Debug.Log (newAlpha);

		float newAlpha = m_Camera.fieldOfView / 60f;


		m_BlackRenderer.color = new Color(1f, 1f, 1f, newAlpha);

		/*if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene ("tanks_inside3");
		}*/

		if (m_Camera.fieldOfView <= 0.5f) {
			//m_Counter.counter++;
			//Debug.Log ("counter after increase:" + m_Counter.counter++);
			//SceneManager.LoadScene ("tanks_inside3");
			newAlpha = 1f;
			m_BlackRenderer.color = new Color(1f, 1f, 1f, newAlpha);
			m_Camera.fieldOfView = initialFOV;
			cactus [counterCactus].GetComponent<Renderer>().enabled = true;

			//m_Instance[counterCactus] = Instantiate(m_CactusPrefab, new Vector3(Random.Range(-1.5f, 1.5f), 0f, Random.Range(-2.5f, 0.5f)), Quaternion.Euler(0f, Random.Range(0f, 359f), 0f)) as GameObject;
			//float randomScale = (counterCactus+1f)/7f + Random.Range (3f, 4f)/10f;
			//m_Instance [counterCactus].transform.localScale = new Vector3 (randomScale, randomScale, randomScale);
			counterCactus++;
			//if (counterScene)
			//counterScene++;
			// next game
			if (counterCactus == 10){
				SceneManager.LoadScene ("tanks_void_round");
			}
		}
	}
}
