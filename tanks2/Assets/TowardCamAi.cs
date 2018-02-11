using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowardCamAi : MonoBehaviour {

	public Transform goal;

	void Start () {
		NavMeshAgent nav = GetComponent<NavMeshAgent>();
		nav.SetDestination (new Vector3(goal.position.x, 0f, goal.position.z));
	}
}
