using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoundAi : MonoBehaviour {

	public float m_TurnSpeed = 180f;       
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
		Destination = new Vector3 (Random.Range(-1*range, range), 0f,  Random.Range(-1*range, range));
		//Debug.Log (Destination);
	}

	// Update is called once per frame
	void Update () {

		if (nav.enabled == true) {
		if (Time.frameCount % 100 == 0){
				Destination = new Vector3 (Random.Range(-1*range, range), 0f,  Random.Range(-1*range, range));
		}


			nav.SetDestination (Destination);
		}

		//OnTriggerEnter ();
	}

	void OnTriggerEnter(Collider other){
		//Debug.Log ("bloop");
		nav.enabled = false;
	}

	private void Turn()
	{
		// Adjust the rotation of the tank based on the player's input.
		// amount of degrees
		float turn = 1f * m_TurnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
	}

	private void Move()
	{
		// Adjust the position of the tank based on the player's input.
		// "what is a vector James?"
		// m_MovementInputValue is -1 or 1
		Vector3 movement = transform.forward * 1f * m_Speed * Time.deltaTime; // make it proportional to second instead of by physics steps

		m_Rigidbody.MovePosition (m_Rigidbody.position + movement);
	}
}
