using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NEW
// Script that destroy the Bubble UI after 5 seconds
public class DestroyThanksUI : MonoBehaviour {
	public int m_PlayerNumber;  
	public float m_MaxLifeTime = 5f;  

	// Use this for initialization
	void Start () {
		Destroy(gameObject, m_MaxLifeTime);
	}

	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (40, 60, 0);
		//transform.position = new Vector3 (-1.5f, 5f, 1.5f);
	}
		
}
