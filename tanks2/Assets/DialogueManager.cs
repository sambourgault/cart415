using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	public Text text;
	public Color color;

	string[] dialogue;
	int dialogueCounter;

	// Use this for initialization
	void Start () {
		color = text.color;
		dialogueCounter = 0;

		dialogue [0] = "I think therefore I am.";
		dialogue [1] = "Yeah definitely!";
		dialogue [2] = "Yeah, sounds so good!";
		dialogue [3] = "1. Who said that? /n2. I think Godot said that!";
		dialogue [4] = "It's Descartes";


	
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogueCounter == 0) {
			text = dialogue [0];

		}
		
	}
}
