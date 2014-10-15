using UnityEngine;
using System.Collections;

public class CharacterDriver : MonoBehaviour {
	public float characterSpeed = .1f;
	public bool playMode = false;
	public GameObject label;
	float currentSpeed;
	int status; //0 - idling, 1 - running, 2 - jumping, 3 - ducking

	// Use this for initialization
	void Start () {
		print("started");
		currentSpeed = 0;
		playMode = false;
		status = 0;
		label.guiText.text = "I am standing.";
	}
	
	// Update is called once per frame
	void Update () {
		if (playMode){
			switch(status){
			case 2:
				label.guiText.text = "I am jumping.";
				currentSpeed = characterSpeed;
				break;
			case 3:
				label.guiText.text = "I am ducking.";
				currentSpeed = characterSpeed;
				break;
			default:
				label.guiText.text = "I am running.";
				currentSpeed = characterSpeed;
				break;
			}
			gameObject.transform.Translate(new Vector3(currentSpeed,0.0f,0.0f));
		}
	}

	public void animate(string pitch, float value){
		switch(pitch){
		case("hi"):
			status = 2;
			break;
		case("high"):
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
