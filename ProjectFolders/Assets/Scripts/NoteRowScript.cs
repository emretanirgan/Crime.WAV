﻿using UnityEngine;
using System.Collections;

public class NoteRowScript : MonoBehaviour {

	public ArrayList notes;
	public ArrayList correctNotes;
	public int noteIndex;
	public int characterIndex = -1;
	public int viewLimit = 100;
	//If space is pressed, the character also moves with the music
	public bool moveChar = false;
	public bool moveCharBegin = false;
//	public GameObject targetChar; 
	public int loseIndex;
	public string[] solPitches;
	public int[] solValues;
	public bool listenNotes = false;


	// Use this for initialization
	void Start () {
		notes = new ArrayList();
		noteIndex = 0;
		Invoke("uncheckLight", 0);
		//Loop the music
		InvokeRepeating("playNotes", 0, 8);

		if(characterIndex == 0){
			solPitches = new string[]{"mid", "high", "mid", "high", "low", "high", "low", "mid", "low", "mid", "low", "high", "high"};
			solValues = new int[]{8,8,4,16,16,8,8,4,8,4,8,4,8};
		}
		else if(characterIndex == 1){
			solPitches = new string[]{"mid", "mid", "low", "mid", "mid", "low", "high", "mid", "low", "high", "mid", "low", "high", "low"};
			solValues = new int[]{4,8,8,4,8,8,8,8,8,8,8,8,8,8};
		}
		else if(characterIndex == 2){
			solPitches = new string[]{"mid", "low", "mid", "low", "high", "mid", "high", "low", "mid", "high", "low", "mid", "mid"};
			solValues = new int[]{4,8,4,8,8,4,8,8,8,16,16,4,8};
		}
		else if(characterIndex == 3){
			solPitches = new string[]{"mid", "low", "high", "mid", "mid", "high", "mid", "low", "high", "mid", "mid"};
			solValues = new int[]{8,4,4,4,8,8,4,16,16,4,4};
		}
	}
	
	// Update is called once per frame
	void Update () {

		//Reorder based on x position 
		GameObject[] blocks = GameObject.FindGameObjectsWithTag("placedNote"+characterIndex.ToString());

		for ( int m = 0; m < blocks.Length; ++m)
		{
			//Debug.Log(blocks[m].transform.position.x);
			NoteScript note = blocks[m].GetComponent<NoteScript>();
			notes.Insert(m, note);
		}

	}

	void playNotes() {
		//Play one iteration of the current notes
		float noteDelay = 0;
		noteIndex=0;
		GameObject slider = GameObject.FindGameObjectWithTag ("slidingBar");
		SlidingBarScript sb = slider.GetComponent<SlidingBarScript>();
		sb.moveMode = true;
		if (listenNotes == true){
			for(int i=0; i<solValues.Length; i++){
				Debug.Log (noteDelay);
				Invoke ("triggerAction", noteDelay);
				noteDelay += 4.0f/solValues[i];
			}
			Invoke ("triggerAction", noteDelay-0.01f);
			return;
		}

		GameObject[] go = GameObject.FindGameObjectsWithTag("placedNote"+characterIndex.ToString());
		if(moveCharBegin){
			moveChar = true;
		}
		for(int i=0; i<go.Length; i++){
			//GameObject go = (GameObject)notes[i];
			NoteScript ns = go[i].GetComponent<NoteScript>();
			Invoke ("triggerAction", noteDelay);
			noteDelay += 4/ns.value;
		}
		//Added this line so that we don't need an end note any more
		Invoke("triggerAction", noteDelay);

	}

	void triggerAction() {


		GameObject burglar = GameObject.FindGameObjectWithTag("Character"+characterIndex.ToString());
		CharacterDriver cd = burglar.GetComponent<CharacterDriver>();
		GameObject[] go = GameObject.FindGameObjectsWithTag("placedNote"+characterIndex.ToString());

		if(listenNotes){
			if(noteIndex == solValues.Length){
				listenNotes = false;
				cd.playMode = false;
				cd.resetPos();
				cd.renderer.enabled = true;
			}
			else{
			//if(noteIndex < solValues.Length){
				cd.playMode = true;
				cd.renderer.enabled = false;
				cd.animate (solPitches[noteIndex], solValues[noteIndex]);
				noteIndex++;
			//}
			//else{
			}
			return;
		}
	
		bool win = false;
		for(int i=0; i<go.Length; i++)
		{
			//NoteScript note = blocks[i].GetComponent<NoteScript>();
			for (int j = i + 1; j < go.Length ; ++j)
			{
				if(go[j].transform.position.x < go[i].transform.position.x)
				{
					GameObject temp = go[i]; 
					go[i] = go[j]; 
					go[j] = temp; 
				}
			}
			
			//Debug.Log(note.pitch);
		}


		//Debug.Log (go.Length); 
		if (noteIndex == go.Length){
			cd.animate("dead", 8);
			cd.playMode = false;
			moveChar = false;
			moveCharBegin = false;
			if(win){
				Debug.Log("won");
				Application.LoadLevel("win_scene");
				//Load the win screen here
			}
			else{
				cd.resetPos();

			}
		}
		else{

			//GameObject go = (GameObject)notes[noteIndex];
			NoteScript ns = go[noteIndex].GetComponent<NoteScript>();
			cd.animate (ns.pitch, ns.value);
			Debug.Log(ns.pitch);
			//If space is pressed, translate character as well

			if(moveChar == true){
				/*for (int i = 0; i< 4; ++i)
				{
					GameObject b = GameObject.FindGameObjectWithTag("Character"+i.ToString());
					CharacterDriver c = b.GetComponent<CharacterDriver>();
					c.playMode = true;
				}*/
				cd.playMode = true;
				//Win/Loss condition check

				loseIndex = -1;
				for (int i=0; i<go.Length; i++){
					//Debug.Log(go.Length);
					NoteScript nsc = go[i].GetComponent<NoteScript>();
					if (characterIndex == 0){
						switch(i){
						case 0:
								win = (nsc.pitch == "mid" && nsc.value == 8);
								break;
						case 1:
								win = (nsc.pitch == "high" && nsc.value == 8);
								break;
						case 2:
								win = (nsc.pitch == "mid" && nsc.value == 4);
								break;
						case 3:
								win = (nsc.pitch == "high" && nsc.value == 16);
								break;
						case 4:
								win = (nsc.pitch == "low" && nsc.value == 16);
								break;
						case 5:
								win = (nsc.pitch == "high" && nsc.value == 8);
								break;
						case 6:
								win = (nsc.pitch == "low" && nsc.value == 8);
								break;
						case 7:
								win = (nsc.pitch == "mid" && nsc.value == 4);
								break;
						case 8:
								win = (nsc.pitch == "low" && nsc.value == 8);
								break;
						case 9:
								win = (nsc.pitch == "mid" && nsc.value == 4);
								break;
						case 10:
								win = (nsc.pitch == "low" && nsc.value == 8);
								break;
						case 11:
								win = (nsc.pitch == "high" && nsc.value == 4);
								break;
						case 12:
								win = (nsc.pitch == "high" && nsc.value == 8);
								break;
							}
					}
					else if (characterIndex == 1){
						switch(i){
						case 0:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 1:
							win = (nsc.pitch == "mid" && nsc.value == 8);
							break;
						case 2:
							win = (nsc.pitch == "low" && nsc.value == 8);
							break;
						case 3:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 4:
							win = (nsc.pitch == "mid" && nsc.value == 8);
							break;
						case 5:
							win = (nsc.pitch == "low" && nsc.value == 8);
							break;
						case 6:
							win = (nsc.pitch == "high" && nsc.value == 8);
							break;
						case 7:
							win = (nsc.pitch == "mid" && nsc.value == 8);
							break;
						case 8:
							win = (nsc.pitch == "low" && nsc.value == 8);
							break;
						case 9:
							win = (nsc.pitch == "high" && nsc.value == 8);
							break;
						case 10:
							win = (nsc.pitch == "mid" && nsc.value == 8);
							break;
						case 11:
							win = (nsc.pitch == "low" && nsc.value == 8);
							break;
						case 12:
							win = (nsc.pitch == "high" && nsc.value == 8);
							break;
						case 13:
							win = (nsc.pitch == "low" && nsc.value == 8);
							break;
						}
					}
					else if (characterIndex == 2){
						switch(i){
						case 0:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 1:
							win = (nsc.pitch == "low" && nsc.value == 8);
							break;
						case 2:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 3:
							win = (nsc.pitch == "low" && nsc.value == 8);
							break;
						case 4:
							win = (nsc.pitch == "high" && nsc.value == 8);
							break;
						case 5:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 6:
							win = (nsc.pitch == "high" && nsc.value == 8);
							break;
						case 7:
							win = (nsc.pitch == "low" && nsc.value == 8);
							break;
						case 8:
							win = (nsc.pitch == "mid" && nsc.value == 8);
							break;
						case 9:
							win = (nsc.pitch == "high" && nsc.value == 16);
							break;
						case 10:
							win = (nsc.pitch == "low" && nsc.value == 16);
							break;
						case 11:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 12:
							win = (nsc.pitch == "mid" && nsc.value == 8);
							break;
						}
					}
					else if (characterIndex == 3){
						switch(i){
						case 0:
							win = (nsc.pitch == "mid" && nsc.value == 8);
							break;
						case 1:
							win = (nsc.pitch == "low" && nsc.value == 4);
							break;
						case 2:
							win = (nsc.pitch == "high" && nsc.value == 4);
							break;
						case 3:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 4:
							win = (nsc.pitch == "mid" && nsc.value == 8);
							break;
						case 5:
							win = (nsc.pitch == "high" && nsc.value == 8);
							break;
						case 6:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 7:
							win = (nsc.pitch == "low" && nsc.value == 16);
							break;
						case 8:
							win = (nsc.pitch == "high" && nsc.value == 16);
							break;
						case 9:
							win = (nsc.pitch == "high" && nsc.value == 16);
							break;
						case 10:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						case 11:
							win = (nsc.pitch == "mid" && nsc.value == 4);
							break;
						}
					}
					if (!win){
						loseIndex = i;
						break;
					}
				}
				if(!win){
					Debug.Log(loseIndex);
					Invoke("loseChar", loseIndex/2.0f);
					Invoke("updateScore", 0 );
							
				}
				//Debug.Log(characterIndex);
				//Debug.Log(characterIndex);
			}
			/*Debug.Log(ns.pitch);
			Debug.Log(ns.value);
			Debug.Log(noteIndex);*/
			noteIndex++;
		}
	
			//Debug.Log(ns.pitch);
		//Debug.Log(ns.value);
		//Debug.Log(noteIndex);
	}

	void OnGUI(){
		//Hacky position, change later
		//GUILayout.BeginArea(new Rect(Screen.width / 4, Screen.height / 2 , Screen.width /2, 200));
		/*GUILayout.BeginArea(new Rect(50, 500, 200, 200));

		if (GUILayout.Button("Play"))
		{
			moveChar = true;
		}*/
	/*	GUILayout.BeginArea(new Rect(50, 300, 200, 200));
		
		newVal = GUILayout.TextField (newVal);
		newPitch = GUILayout.TextField (newPitch);
		if (GUILayout.Button("Add Note"))
		{
			GameObject note = (GameObject)Instantiate (Resources.Load ("Note"));
			NoteScript ns = note.GetComponent<NoteScript>();
			ns.value = float.Parse (newVal);
			ns.pitch = newPitch;
			note.transform.localScale = new Vector3(ns.value, 1, 1);
			note.transform.position = new Vector3(notePos,0,-10);
			notePos += ns.value;

			newVal = "Note Length";
			newPitch = "Pitch";

			notes.Add (note);

		}*/

	/*	GUILayout.BeginArea(new Rect(20, 3.5f * Screen.height/ 4 + 25, 100, 200));

		if (GUILayout.Button("See Map")){
			if(viewLimit > 0){
				GameObject gLight = GameObject.FindGameObjectWithTag("globalLight");
				Light light = gLight.GetComponent<Light>();
				light.intensity = 0.5f;
				Invoke("uncheckLight", 6);
				viewLimit--;
			}
		}
	
		GUILayout.EndArea ();*/
	}

	void uncheckLight(){
		GameObject gLight = GameObject.FindGameObjectWithTag("globalLight");
		Light light = gLight.GetComponent<Light>();
		light.intensity = 0.0f;
	}

	void updateScore()
	{
		int s = PlayerPrefs.GetInt ("currentScore") -10;
		PlayerPrefs.SetInt ("currentScore", s);		
		float l = PlayerPrefs.GetFloat ("currentLives") - 1.0f;
		PlayerPrefs.SetFloat ("currentLives", l);	
	}
	void loseChar(){
		GameObject burglar = GameObject.FindGameObjectWithTag("Character"+characterIndex.ToString());
		CharacterDriver cd = burglar.GetComponent<CharacterDriver>();
		cd.resetPos();
		moveChar = false;

	}
}
