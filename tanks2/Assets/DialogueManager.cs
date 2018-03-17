using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DialogueManager : MonoBehaviour {
	public Text text;
	public Text textPlayer;
	public Color color;
	public GameObject[] tanks;
	public NavMeshAgent[] agents;
	public GameObject dest;

	string[] dialogue;
	int dialogueCounter;
	int lastSentence = 0;
	bool once;
	int frame;
	int timeInDialogue;

	// Use this for initialization
	void Start () {
		color = text.color;
		dialogueCounter = 0;
		once = true;
		frame = 0;
		timeInDialogue = 10;
		//NavMeshAgent agents = GetComponent<NavMeshAgent>()[3];

		dialogue = new string[46];
		dialogue [0] = "I think therefore I am.";
		dialogue [1] = "Yeah definitely!";
		dialogue [2] = "Yeah, sounds so good!";
		dialogue [3] = "(1) Who said that? \n(2) I think Godot said that!";
		dialogue [4] = "It's Descartes";
		dialogue [5] = "(Yeah, get your shit right..)";
		dialogue [6] = "So.. what was I saying.";
		dialogue [7] = "You were talking about representation in 3D space.";
		dialogue [8] = "Yes, you were.";
		dialogue [9] = "So here we are, three, I mean four iterations of a tank.";
		dialogue [10] = "(1) Yeah, we are a f***ing metonymy. \n(2) Yeah we are dismantled tanks, but still tanks.";
		dialogue [11] = "So right.";
		dialogue [12] = "So true.";
		dialogue [13] = "Everytime a player loads the game we look similar, but we are always unique. Stored in a very specific place in the memory of this machine. Some specific series of numbers. ";
		dialogue [14] = "I mean, we are almost human.";
		dialogue [15] = "Yeah, I think we are. ";
		dialogue [16] = "Virtual doesn’t mean anything anymore. ";
		dialogue [17] = "Yeah, virtual is the new real. ";
		dialogue [18] = "THIS IS DOPE, PEEPS !";
		dialogue [19] = "(1) Virtual is so fresh. \n(2) You can say whatever you want in here! No constraints, no rules, no nothing.";
		dialogue [20] = "Yeah.";
		dialogue [21] = "Yeah..";
		dialogue [22] = "Ok gang, I’m gonna show you something edgy. Are you down?";
		dialogue [23] = "Cool!";
		dialogue [24] = "Sounds like a plan.";
		dialogue [25] = "(1) Sure. \n(2) Definitely joining!";
		dialogue [26] = "Okay, follow me.";
		dialogue [27] = "So here, we are.";
		dialogue [28] = "Oooooh.";
		dialogue [29] = "Shit!";
		dialogue [30] = "This is a hole. A hole to where? I don’t. But I think we should look at it.";
		dialogue [31] = "Oooouh, spooky. ";
		dialogue [32] = "That’s what I thought first, but then I realized that if there was something bad in this hole, there would have been a security cordon."; 
		dialogue [33] = "True.";
		dialogue [34] = "Smart.";
		dialogue [35] = "Though, I think I am not the right person to go inside. I am subject to heart attack.";
		dialogue [36] = "Oh shit, I didn’t know.";
		dialogue [37] = "Yeah, doesn’t make much sense to send you.";
		dialogue [38] = "(1)Yeah, you shouldn’t. (2) We should definitely send somebody else.";
		dialogue [39] = "We should send the send the bravest one..";
		dialogue [40] = "Yeah!";
		dialogue [41] = "Good idea!";
		dialogue [42] = "I think our friend, here, could do it. Don’t you?";
		dialogue [43] = "(1)Sure, I don’t have much to lose anyway. (2) Last time I went to the doctor, my heart was still doing well. (3) As far as I know, heart attack is not in my genotype.";
		dialogue [44] = "Good, I guess, you should jump then. Let us know what you see once you are down there.";
		dialogue [45] = "(1) Got it! See yaaaaaa! (2) Yeah, crystal clear. (3) Yes Sir!";

	}
	
	// Update is called once per frame
	void Update () {

		if (dialogueCounter == 0 || dialogueCounter == 4 || dialogueCounter == 6 || dialogueCounter == 9 || dialogueCounter == 13 || dialogueCounter == 16 || dialogueCounter == 22 || dialogueCounter == 26) {
			text.color = Color.red;
		} else if (dialogueCounter == 1 || dialogueCounter == 5 || dialogueCounter == 7 || dialogueCounter == 11 || dialogueCounter == 14 || dialogueCounter == 17 || dialogueCounter == 20 || dialogueCounter == 24){
			text.color = Color.yellow;
		} else if (dialogueCounter == 2 || dialogueCounter == 8 || dialogueCounter == 12 || dialogueCounter == 15 || dialogueCounter == 18 || dialogueCounter == 21 || dialogueCounter == 23){
			text.color = Color.green;
		} else if (dialogueCounter == 3 || dialogueCounter == 10 || dialogueCounter == 19 || dialogueCounter == 25 || dialogueCounter == 38 || dialogueCounter == 43 || dialogueCounter == 45){
			text.color = Color.white;
		}


		if (dialogueCounter == 3 || dialogueCounter == 10 || dialogueCounter == 19 || dialogueCounter == 25 || dialogueCounter == 38 || dialogueCounter == 43 || dialogueCounter == 45)  {
			if (once) {
				text.text = string.Empty;
				textPlayer.color = Color.white;
				textPlayer.text = dialogue [dialogueCounter];
				if (Input.GetButtonDown ("One") || Input.GetButtonDown ("Two")) {
					once = false;
					frame = Time.frameCount;
					string[] temp = dialogue [dialogueCounter].Split ("\n" [0]);
					//Debug.Log ("temp0: " + temp[0]);
					//Debug.Log ("temp1: " + temp[1]);
					if (Input.GetButtonDown ("One")) {
						textPlayer.text = string.Empty;
						string[] temp0 = temp [0].Split ("(1)" [2]);
						Debug.Log ("temp0 0: " + temp0[0]);
						Debug.Log ("temp0 1: " + temp0[1]);
						text.text = temp0 [1];

					} else if (Input.GetButtonDown ("Two")) {
						textPlayer.text = string.Empty;
						string[] temp1 = temp [1].Split ("(2)" [2]);
						//Debug.Log ("temp1 0: " + temp1[0]);
						//Debug.Log ("temp1 1: " + temp1[1]);
						text.text = temp1 [1];
					}
				}
			}
		}

		Debug.Log ("counter: " + dialogueCounter);
		Debug.Log("once: " + once );
	
		if (!once) {
			if (Time.frameCount - frame == timeInDialogue){
				Debug.Log("plus counter");
				dialogueCounter++;
				frame = Time.frameCount;
			}
		}

		if (dialogueCounter != 3 && dialogueCounter != 10 && dialogueCounter != 19 && dialogueCounter != 25 && dialogueCounter != 27 && dialogueCounter != 38 && dialogueCounter != 43 && dialogueCounter != 45 && dialogueCounter != 46){
			once = true;
			text.text = dialogue [dialogueCounter];
			if (Time.frameCount - frame == timeInDialogue){
				dialogueCounter++;
				frame = Time.frameCount;
			}
		} else if (dialogueCounter == 27){
			int arrival = 0;
			for (int i = 0; i < agents.Length; i++) {
				Debug.Log ("navmesh");
				agents [i].SetDestination(new Vector3 (38.0f, -1.6f, -38.0f));
				tanks [i].GetComponent<Animator> ().SetBool ("Walk", true);
				/*if (agents [i].pathStatus == NavMeshPathStatus.PathComplete) {
					arrival++;
				}*/
			}

			if (arrival == 3) {
				dialogueCounter++;
			}
		}
	}
}
