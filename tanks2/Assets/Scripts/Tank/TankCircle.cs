using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCircle : MonoBehaviour {

	private Rigidbody m_Rigidbody;
	private float RotateSpeed = 0.2f;
	private float Radius = 5f;

	private Vector3 centre;
	private float angle = 0;
	private float yRotation = 90f;
	private float damping;

	// first function called
	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		centre = transform.position;
		damping = 1f; //Random.Range(5f, 12f);
		m_Rigidbody.MoveRotation (Quaternion.Euler(0, 90f, 0));
	}

	private void Update()
	{
			
		angle += RotateSpeed * Time.deltaTime;
		//Debug.Log (angle * 180 / 3.1416f);

		var offset = (new Vector3(Mathf.Sin(angle ), 0, Mathf.Cos(angle)) )* Radius ;
		transform.position = centre + offset;

		Vector3 radDirection = (transform.position - centre);
		//Vector3 direction = 


		//float turn = 1 * 1 * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, 90f + (angle * 180 / 3.1416f), 0f);
		//Debug.Log ((angle*180/3.1416f));
		m_Rigidbody.MoveRotation (turnRotation);

		//yRotation += RotateSpeed;
		//transform.eulerAngles = new Vector3(0, yRotation, 0);
	}

}
