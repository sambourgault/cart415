using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;       
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;    
    public Slider m_AimSlider;           
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;         
    public float m_MinLaunchForce = 15f; 
    public float m_MaxLaunchForce = 30f; 
    public float m_MaxChargeTime = 0.75f;

	// NEW
	// variables containing bubble prefabs
	public GameObject m_BubblePrefab;
	public GameObject m_BubblePrefab2;
	public GameObject m_BubblePrefab3;
	public GameObject m_BubblePrefab4;
	    
    private string m_FireButton;         
    private float m_CurrentLaunchForce;  
    private float m_ChargeSpeed;         
    private bool m_Fired;      

	// NEW
	// variables for the bubble's transform
	private Quaternion m_BubbleRotation = Quaternion.Euler(40, 60, 0);
	private GameObject m_Bubble;
	private int m_CounterBubble = 0;
	private TankShooting m_OtherTank;

    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
		//NEW
		// record the other tank's script for shooting
		GameObject[] tanks = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < tanks.Length; i++) {
			if (tanks[i].GetComponent<TankShooting>().m_PlayerNumber != m_PlayerNumber) {
				m_OtherTank = tanks[i].GetComponent<TankShooting>();
			}
		}

        m_FireButton = "Fire" + m_PlayerNumber;

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }
    

    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.
		m_AimSlider.value = m_MinLaunchForce;

		if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired) {
			// at max charge, not fired yet
			m_CurrentLaunchForce = m_MaxLaunchForce;
			//Fire ();
		} else if (Input.GetButtonDown (m_FireButton)) {
			// have we pressed fire for the first time?
			//m_Fired = false;
			//m_CurrentLaunchForce = m_MinLaunchForce;

			//m_ShootingAudio.clip = m_ChargingClip;
			m_ShootingAudio.Play ();

		/*} else if (Input.GetButton (m_FireButton) && !m_Fired) {
			// holding the fire button, not yet fired
			m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
			// set the slider value to lauch force
			m_AimSlider.value = m_CurrentLaunchForce;*/

		} else if (Input.GetButtonUp (m_FireButton) && !m_Fired) {
			// we released the button, having not fired yet, so we fire
			//Fire();

			// NEW
			// call to the function Talk
			Talk ();
		}
    }
		

	// NEW
	// new function that spawn a Bubble
	private void Talk(){


		// check if a bubble exists and create one if not, with the right message
		// check if the other tank as answered also before changing the message
		if (m_Bubble == null) {
			m_CounterBubble++;
			if (m_CounterBubble > 6 && m_OtherTank.m_CounterBubble > 6) {
				m_Bubble = Instantiate (m_BubblePrefab4, new Vector3 (transform.position.x - 1.5f, transform.position.y + 5.0f, transform.position.z + 1.5f), m_BubbleRotation) as GameObject;
				m_Bubble.transform.parent = gameObject.transform;

			} else if (m_CounterBubble > 4 && m_OtherTank.m_CounterBubble > 4) {
				m_Bubble = Instantiate (m_BubblePrefab3, new Vector3 (transform.position.x - 1.5f, transform.position.y + 5.0f, transform.position.z + 1.5f), m_BubbleRotation) as GameObject;
				m_Bubble.transform.parent = gameObject.transform;

			} else if (m_CounterBubble > 1  && m_OtherTank.m_CounterBubble > 1) {
				m_Bubble = Instantiate (m_BubblePrefab2, new Vector3 (transform.position.x - 1.5f, transform.position.y + 5.0f, transform.position.z + 1.5f), m_BubbleRotation) as GameObject;
				m_Bubble.transform.parent = gameObject.transform;

			} else if (m_CounterBubble >= 0  && m_OtherTank.m_CounterBubble >= 0) {
				m_Bubble = Instantiate (m_BubblePrefab, new Vector3 (transform.position.x - 1.5f, transform.position.y + 5.0f, transform.position.z + 1.5f), m_BubbleRotation) as GameObject;
				m_Bubble.transform.parent = gameObject.transform;
			}
		}
	}
		
		
    private void Fire()
    {
        // Instantiate and launch the shell.
		m_Fired = true;

		// instantiate doesnt return a rigidbody (but an object) so we add the last bit to refer to the rigidbody
		Rigidbody shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

		shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

		m_ShootingAudio.clip = m_FireClip;
		m_ShootingAudio.Play ();

		m_CurrentLaunchForce = m_MinLaunchForce;
    }
}