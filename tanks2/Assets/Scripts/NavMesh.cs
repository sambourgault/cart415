using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour {
	public NavMeshAgent agent;
	public GameObject activePlayer;
	private Animator animator;

	private int speedId;
	private int rotateId;

	public Vector3 moveTarget;
	public bool isInteractable;
	public bool pathReached;
	public bool canMove;

	public Quaternion rot;

	public GameObject currentInteractable;

	public enum MoveFSM{
		findPosition,
		move,
		turnToFace,
		interact
	}

	public MoveFSM moveFSM;

	public enum TurnFSM
	{
		Empty,
		TriggerTurn,
		WaitForTurnEnd
	}

	public TurnFSM turnFSM;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		speedId = Animator.StringToHash ("Speed");
		rotateId = Animator.StringToHash ("Angle");

		agent = GetComponent<NavMeshAgent> ();
		canMove = true;
		pathReached = false;
		activePlayer = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)){ //&& !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() ) {
			GetInteraction ();
			Debug.Log ("booba");
		}

		MoveStates ();	
	}

	public void MoveStates(){
		switch (moveFSM) 
		{
		case MoveFSM.findPosition:
			break;

		case MoveFSM.move:
			Move ();
			break;
		case MoveFSM.turnToFace:
			TurnToFace ();
			break;
		case MoveFSM.interact:
			break;
		}
	}

	public void Move(){
		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				animator.SetFloat (speedId, 0f);
				pathReached = true;
				moveFSM = MoveFSM.turnToFace;
			}
		}
	}

	public void TurnToFace(){
		if (currentInteractable != null) {
			if (pathReached) {
				Vector3 dir = currentInteractable.transform.position - transform.position;
				dir.y = 0;
				rot = Quaternion.LookRotation (dir);
				transform.rotation = Quaternion.Lerp (transform.rotation, rot, 5f * Time.deltaTime);

				if ((rot.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < .01) {
					pathReached = false;
					animator.SetBool ("Turning", false);
					turnFSM = TurnFSM.Empty;
					moveFSM = MoveFSM.interact;
				}
			}
		} else if (currentInteractable == null){
			moveFSM = MoveFSM.findPosition;
		}
	
	}

	private void GetInteraction(){
		if (canMove) {
		
			Ray interactionRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit interactionInfo;

			Debug.Log ("mouse pos: " + Input.mousePosition);

			if (Physics.Raycast (interactionRay, out interactionInfo, Mathf.Infinity)) {
				Debug.Log ("blabla_raycast");
				if (interactionInfo.collider.tag == "Interactable") {
					currentInteractable = interactionInfo.collider.gameObject;
					isInteractable = true;
					//currentInteractable = 

					agent.destination = currentInteractable.GetComponent<Interactable> ().interactionPoint.transform.position;
					currentInteractable.GetComponent<Interactable> ().isClicked = true;

					moveTarget = agent.destination;
					animator.SetFloat (speedId, 3f);

					pathReached = false;
					moveFSM = MoveFSM.move;
				} else {
					if (currentInteractable != null) {
						currentInteractable.GetComponent<Interactable> ().isClicked = false;
						currentInteractable = null;
					}
					isInteractable = false;
					moveTarget = interactionInfo.point;
					agent.destination = interactionInfo.point;
					//Debug.Log ("agent dest: " + agent.destination);

					animator.SetFloat (speedId, 3f);
					//Debug.Log ("float speed: " + animator.GetFloat ("Speed"));

					pathReached = false;
					moveFSM = MoveFSM.move;
				}
			}
	
		}
	}
}
