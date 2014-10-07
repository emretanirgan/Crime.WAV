using UnityEngine;
using System.Collections;

public class CharacterDriver : MonoBehaviour {
	public float characterSpeed;
	public GameObject label;
	float currentSpeed;
	int status; //0 - idling, 1 - running, 2 - jumping, 3 - ducking

	// Use this for initialization
	void Start () {
		print("started");
		currentSpeed = 0;
		status = 0;
		label.guiText.text = "I am standing.";
	}
	
	// Update is called once per frame
	void Update () {
		switch(status){
		case 2:
			label.guiText.text = "I am jumping.";
			break;
		case 3:
			label.guiText.text = "I am ducking.";
			break;
		default:
			label.guiText.text = "I am running.";
			break;
		}
	}

	public void animate(string pitch, float value){
		switch(pitch){
		case("hi"):
			status = 2;
			break;
		case("low"):
			status = 3;
			break;
		default:
			status = 1;
			break;
		}
	}
}
