using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public GameObject interactionPoint;
	public Animator playerAnimator;
	public GameObject currentplayer;

	public bool isClicked = false;

	public virtual void FindPlayer(GameObject player){
		currentplayer = player;
		playerAnimator = currentplayer.GetComponent<Animator> ();
	}

	public virtual void Interact(GameObject player){
		//Debug.Log ("Interaction with base class");
	}
}
