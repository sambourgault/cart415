using UnityEngine;

public class CameraControl1 : MonoBehaviour
{
    public float m_DampTime = 0.2f;                 
    public float m_ScreenEdgeBuffer = 4f;           
    public float m_MinSize = 6.5f;                  
    [HideInInspector] public Transform[] m_Targets; 


    private Camera m_Camera;                        
    private float m_ZoomSpeed;                      
    private Vector3 m_MoveVelocity;                 
    private Vector3 m_DesiredPosition;  
	private Rigidbody m_Rigidbody; 
	private string m_TurnAxisName; 
	private float m_TurnInputValue;  
	public float m_TurnSpeed = 0.001f; 

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
		m_Rigidbody = GetComponent<Rigidbody>();
	
    }

	private void OnEnable ()
	{
		m_Rigidbody.isKinematic = false;
		m_TurnInputValue = 0f;
	}

	private void Start(){
		m_TurnAxisName = "VerticalTraffic" ;


	}

	private void Update()
	{
		m_TurnInputValue = Input.GetAxis (m_TurnAxisName);
	}

    private void FixedUpdate()
    {
        //Move();
        //Zoom();
		Turn();
    }


    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


	private void Turn(){
		// Adjust the rotation of the tank based on the player's input.
		// amount of degrees
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
	}

    private void FindAveragePosition()
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
    }
}