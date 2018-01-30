using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTowardsGod : MonoBehaviour {

	public float m_DampTime = 10f;   
	public GameObject camera;

	private Rigidbody m_Rigidbody;
	private float RotateSpeed = 0.2f;
	private float Radius = 5f;

	private Vector3 centre;
	private float angle = 0;
	private float yRotation = 90f;
	private float yVelocity = 0f; 
	private float xVelocity = 0f; 
	private float distance = 26f;


	// first function called
	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		//centre = transform.position;
		//m_Rigidbody.MoveRotation (Quaternion.Euler(0, 90f, 0));
	}

	private void Update()
	{
		float angleH = Mathf.Atan ((camera.transform.position.x - transform.position.x)/(camera.transform.position.z - transform.position.z));
		float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleH*180/3.1416f, ref yVelocity, 30 * Time.deltaTime);

		float angleV = Mathf.Atan (((camera.transform.position.y-3f) - transform.position.y)/(camera.transform.position.z - transform.position.z));
		float xAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x, -1*angleV*180/3.1416f, ref xVelocity, 30 * Time.deltaTime);
		//Vector3 position = camera.transform.position;
		//position += Quaternion.Euler(0, yAngle, 0) * new Vector3(0, 0, -distance);
		//transform.position = position;
		//transform.LookAt(camera.transform);
		//m_Rigidbody.MoveRotation(Quaternion.Euler (0, yAngle, 0));
		transform.rotation = Quaternion.Euler (xAngle, yAngle, 0);
		//angle += RotateSpeed * Time.deltaTime;
		//Debug.Log (angle * 180 / 3.1416f);

		//var offset = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * Radius;
		//transform.position = centre + offset;

		//Vector3 radDirection = (transform.position - centre);
		//Vector3 direction = 


		//float turn = 1 * 1 * Time.deltaTime;
		//Quaternion turnRotation = Quaternion.Euler (0f, 90f + (angle * 180 / 3.1416f), 0f);
		//Debug.Log ((angle*180/3.1416f));
		//m_Rigidbody.MoveRotation (turnRotation);
		//transform.eulerAngles = Vector3.SmoothDamp(transform.position, Camera.transform.position, ref m_MoveVelocity, m_DampTime);


		//yRotation += RotateSpeed;
		//transform.eulerAngles = new Vector3(0, yRotation, 0);
	}

}
