using UnityEngine;
using System.Collections;

public class NoteRowScript : MonoBehaviour {

	public ArrayList notes;
	public int noteIndex;
	public int characterIndex = -1;
	public int viewLimit = 3;
	//If space is pressed, the character also moves with the music
	public bool moveChar = false;

	//Adding new notes
	public string newPitch = "Pitch";
	public string newVal = "Note Length";
	public float notePos = -10;

	// Use this for initialization
	void Start () {
		notes = new ArrayList();
		noteIndex = 0;

		//Remove once block placing UI is implemented
		/*GameObject[] blocks = GameObject.FindGameObjectsWithTag("Note");
		for(int i=0; i<blocks.Length; i++){
			notes.Add (blocks[i]);
			Debug.Log(blocks[i]);
		}*/
		Invoke("uncheckLight", 0);
		//Loop the music
		InvokeRepeating("playNotes", 0, 4);
	}
	
	// Update is called once per frame
	void Update () {

		//Reorder based on x position 
		GameObject[] blocks = GameObject.FindGameObjectsWithTag("placedNote");
		for(int i=0; i<blocks.Length; i++)
		{
			//NoteScript note = blocks[i].GetComponent<NoteScript>();
			for (int j = i + 1; j < blocks.Length ; ++j)
			{
				if(blocks[j].transform.position.x < blocks[i].transform.position.x)
				{
					GameObject temp = blocks[i]; 
					blocks[i] = blocks[j]; 
					blocks[j] = temp; 
				}
			}

			//Debug.Log(note.pitch);
		}

		notes.Clear();
		for ( int m = 0; m < blocks.Length; ++m)
		{
			Debug.Log(blocks[m].transform.position.x);
			NoteScript note = blocks[m].GetComponent<NoteScript>();
			notes.Add (note);
		}



	}

	void playNotes() {
		//Play one iteration of the current notes
		float noteDelay = 0;
		noteIndex=0;
		GameObject[] go = GameObject.FindGameObjectsWithTag("placedNote");
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
		GameObject[] go = GameObject.FindGameObjectsWithTag("placedNote");
		//Debug.Log (go.Length); 
		if (noteIndex == go.Length){
			cd.animate("dead", 8);
			cd.playMode = false;
			moveChar = false;
		}
		else{

			//GameObject go = (GameObject)notes[noteIndex];
			NoteScript ns = go[noteIndex].GetComponent<NoteScript>();
			cd.animate (ns.pitch, ns.value);
			//Debug.Log(ns.pitch);
			//If space is pressed, translate character as well
			if(moveChar == true){
				cd.playMode = true;
			}
			noteIndex++;
		}
		//Debug.Log(ns.pitch);
		//Debug.Log(ns.value);
		//Debug.Log(noteIndex);
	

	}

	void OnGUI(){
		//Hacky position, change later
		//GUILayout.BeginArea(new Rect(Screen.width / 4, Screen.height / 2 , Screen.width /2, 200));
		GUILayout.BeginArea(new Rect(50, 500, 200, 200));

		if (GUILayout.Button("Play"))
		{
			moveChar = true;

		}
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
		if (GUILayout.Button("See Map")){
			if(viewLimit > 0){
				GameObject gLight = GameObject.FindGameObjectWithTag("globalLight");
				Light light = gLight.GetComponent<Light>();
				light.intensity = 0.5f;
				Invoke("uncheckLight", 3);
				viewLimit--;
			}
		}
	
		GUILayout.EndArea ();
	}

	void uncheckLight(){
		GameObject gLight = GameObject.FindGameObjectWithTag("globalLight");
		Light light = gLight.GetComponent<Light>();
		light.intensity = 0.0f;
	}
}
