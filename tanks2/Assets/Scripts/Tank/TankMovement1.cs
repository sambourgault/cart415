﻿using UnityEngine;

public class TankMovement1 : MonoBehaviour
{
    //public int m_PlayerNumber = 1;         
    public float m_Speed = 0.1f;            
    //public float m_TurnSpeed = 180f;       
    //public AudioSource m_MovementAudio;    
    //public AudioClip m_EngineIdling;       
    //public AudioClip m_EngineDriving;      
    //public float m_PitchRange = 0.2f;

    
    private string m_MovementAxisName;     
    private string m_TurnAxisName;         
    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue;    
    private float m_TurnInputValue;        
   // private float m_OriginalPitch;         

	// first function called
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

	// second function called, when awake is done
    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

	// kinematics = no force can't affect it
	// you want physics but not physics forces to apply
    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        //m_MovementAxisName = "Vertical" + m_PlayerNumber;
        //m_TurnAxisName = "Horizontal" + m_PlayerNumber;

		// start with original pitch
		//m_OriginalPitch = m_MovementAudio.pitch; // reference to Audio Source (drag and drop to be specific since a tank has two)
    }


    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
		// find values of two axis and store them
		//m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
		//m_TurnInputValue = Input.GetAxis (m_TurnAxisName);

		// call the function that manage the audio
		//EngineAudio ();
    }


   /* private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.

		if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f) {
			// than the tanks is idling.
			if (m_MovementAudio.clip == m_EngineDriving){
				m_MovementAudio.clip = m_EngineIdling;
				m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				// you need to replay an audiosource, everytime you change it
				m_MovementAudio.Play ();
			} 
		} else {
			// than the tanks is moving.
			if (m_MovementAudio.clip == m_EngineIdling){
				m_MovementAudio.clip = m_EngineDriving;
				m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				// you need to replay an audiosource, everytime you change it
				m_MovementAudio.Play ();
			} 	
		}
    }*/

	// run every physics steps (physics engine updates by steps)
	// when do we use it??
    private void FixedUpdate()
    {
        // Move and turn the tank.
		Move();
		//Turn ();
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
		// "what is a vector James?"
		// m_MovementInputValue is -1 or 1
		Vector3 movement = transform.forward * 1 * m_Speed * Time.deltaTime; // make it proportional to second instead of by physics steps
    	
		m_Rigidbody.MovePosition (m_Rigidbody.position + movement);


	}


    /*private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
		// amount of degrees
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
    }*/
}