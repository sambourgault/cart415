using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CameraControl_void1 : MonoBehaviour
{
	public float m_DampTime = 0.2f;                 
	public float m_ScreenEdgeBuffer = 4f;           
	public float m_MinSize = 6.5f;                  
	[HideInInspector] public Transform[] m_Targets; 
	public float m_Speed = 10f;  
	public Text m_MessageText;


	private Camera m_Camera; 
	private Rigidbody m_Rigidbody;         

	private float m_ZoomSpeed;                      
	private Vector3 m_MoveVelocity;                 
	private Vector3 m_DesiredPosition;  

	private string m_VerticalMovement;
	private string m_HorizontalMovement;
	private float m_VerticalValue;
	private float m_HorizontalValue;

	private int initialFrame;


	private void Awake()
	{
		m_Camera = GetComponentInChildren<Camera>();
		m_Rigidbody = m_Camera.GetComponent<Rigidbody>();
		m_VerticalValue = 0f;
		m_HorizontalValue = 0f;
	}


	private void Start(){
		m_VerticalMovement = "VerticalCam";
		m_HorizontalMovement = "HorizontalCam";

		initialFrame = Time.frameCount;

	}


	private void Update()
	{
		if ((Time.frameCount - initialFrame) > 100){
			Debug.Log ("bloop");
			m_MessageText.text = string.Empty;
		}
		// Store the player's input and make sure the audio for the engine is playing.
		// find values of two axis and store them
		m_VerticalValue = Input.GetAxis(m_VerticalMovement);
		m_HorizontalValue = Input.GetAxis(m_HorizontalMovement);

		if ((Time.frameCount- initialFrame)  > 1100) {
			SceneManager.LoadScene ("tanks_mother");
		}
		// call the function that manage the audio
	}


	private void FixedUpdate()
	{		
		Move();
	}
		


	private void Move(){
		Vector3 movement = new Vector3(m_Speed, 0, 0) * m_HorizontalValue * m_Speed * Time.deltaTime; // make it proportional to second instead of by physics steps
		//m_Rigidbody.MovePosition (m_Rigidbody.position + movement);

		Vector3 movement2 = new Vector3(0, m_Speed, 0) * m_VerticalValue * m_Speed * Time.deltaTime; // make it proportional to second instead of by physics steps
		//m_Rigidbody.MovePosition (m_Rigidbody.position + movement + movement2);

		m_DesiredPosition = m_Rigidbody.position + movement + movement2;

		//transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
		transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
	
		if (m_Camera.transform.position.x < -58.7f) {
			transform.position = new Vector3(21.3f, m_Rigidbody.transform.position.y, m_Rigidbody.transform.position.z);

		} else if (m_Camera.transform.position.x > 21.3f){
			transform.position = new Vector3(-58.7f, m_Rigidbody.transform.position.y, m_Rigidbody.transform.position.z);
		}

		if (m_Camera.transform.position.y < -30f) {
			transform.position = new Vector3( m_Rigidbody.transform.position.x, 50f, m_Rigidbody.transform.position.z);

		} else if (m_Camera.transform.position.y > 50f){
			transform.position = new Vector3(m_Rigidbody.transform.position.x, -30f, m_Rigidbody.transform.position.z);
		}

	}

	/*private void FindAveragePosition()
	{
		Vector3 averagePos = new Vector3();
		int numTargets = 0;

		for (int i = 0; i < m_Targets.Length; i++)
		{
			if (!m_Targets[i].gameObject.activeSelf)
				continue;

			averagePos += m_Targets[i].position;
			numTargets++;
		}

		if (numTargets > 0)
			averagePos /= numTargets;

		averagePos.y = transform.position.y;

		m_DesiredPosition = averagePos;
	}


	private void Zoom()
	{
		float requiredSize = FindRequiredSize();
		m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
	}


	private float FindRequiredSize()
	{
		Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

		float size = 0f;

		for (int i = 0; i < m_Targets.Length; i++)
		{
			if (!m_Targets[i].gameObject.activeSelf)
				continue;

			Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

			Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
		}

		size += m_ScreenEdgeBuffer;

		size = Mathf.Max(size, m_MinSize);

		return size;
	}


	public void SetStartPositionAndSize()
	{
		FindAveragePosition();

		transform.position = m_DesiredPosition;

		m_Camera.orthographicSize = FindRequiredSize();
	}*/
}