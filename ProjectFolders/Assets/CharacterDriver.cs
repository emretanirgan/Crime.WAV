using UnityEngine;
using System.Collections;

public class CharacterDriver : MonoBehaviour {
	public float characterSpeed = .1f;
	public bool playMode = false;
	public GameObject label;
	public AudioClip a440;
	public int burglar_num; // 0 - strong, 1 - stealth, 2 - sexy, 3 - hacker
	float currentSpeed;
	int status; //0 - idling, 1 - running, 2 - jumping, 3 - ducking, -1 - dead
	int note; //0 - C, 1 - C#, 2 - D, 3 - Eb
			  //4 - E, 5 - F, 6 - F#, 7 - G
			  //8 - G#, 9 - A, 10 - Bb, 11 - B

	public Texture idleTex;
	public Texture runTex;
	public Texture jumpTex;
	public Texture duckTex;


	// Strong character should play notes 0,1,2

	// Use this for initialization
	void Start () {
//		print("started");
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
			case -1:
				label.guiText.text = "I got stuck!";
				currentSpeed = 0.0f;
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
			note = 2;
			renderer.material.mainTexture = jumpTex;
			break;
		case("high"):
			status = 2;
			note = 2;
			renderer.material.mainTexture = jumpTex;
			break;
		case("low"):
			status = 3;
			note = 0;
			renderer.material.mainTexture = duckTex;
			break;
		case("dead"):
			status = -1;
			renderer.material.mainTexture = idleTex;
			break;
		default:
			status = 1;
			note = 1;
			renderer.material.mainTexture = runTex;
			break;
		}

		if(status > 0){
//			Debug.Log(AudioSettings.dspTime);
			playAudio(note, value);
		}
	}

	public void playAudio(int note, float value){
//		print("play on");
		audio.pitch = Mathf.Pow(2, (note-4.0f)/12.0f);
		audio.Play();
		double t0 = AudioSettings.dspTime;
		audio.SetScheduledEndTime(t0+(4.0f/value));
	}


}
