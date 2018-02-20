using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLine : MonoBehaviour {

	//public float m_TurnSpeed = 180f;       
	public float m_Speed = 12f;            


	Transform player;
	NavMeshAgent nav;

	private Rigidbody m_Rigidbody;     
	private Vector3 Destination;
	private float range = 25f;


	// Use this for initialization
	void Awake () {
		//player = GameObject.Fin
		nav = GetComponent<NavMeshAgent>();
	}

	void Start(){
		Destination = new Vector3 (400, transform.position.y, transform.position.z);
		nav.SetDestination (Destination);

		//Debug.Log (Destination);
	}

	// Update is called once per frame
	void Update () {

		/*if (nav.enabled == true) {
		if (Time.frameCount % 100 == 0){
				Destination = new Vector3 (Random.Range(-1*range, range), 0f,  Random.Range(-1*range, range));
		}*/


		//nav.SetDestination (Destination);
	//}

		//OnTriggerEnter ();
	}

}
