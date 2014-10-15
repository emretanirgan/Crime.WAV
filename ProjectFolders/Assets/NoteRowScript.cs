using UnityEngine;
using System.Collections;

public class NoteRowScript : MonoBehaviour {

	public ArrayList notes;
	public int noteIndex;
	public int characterIndex = -1;
	public int viewLimit = 3;

	//Adding new notes
	public string newPitch = "Pitch";
	public string newVal = "Note Length";
	public float notePos = -10;

	// Use this for initialization
	void Start () {
		notes = new ArrayList();
		noteIndex = 0;

		//Remove once block placing UI is implemented
		GameObject[] blocks = GameObject.FindGameObjectsWithTag("Note");
		for(int i=0; i<blocks.Length; i++){
			notes.Add (blocks[i]);
			Debug.Log(i);
		}
		Invoke("uncheckLight", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("space")){
			playNotes ();
		}
	}

	void playNotes() {
		float noteDelay = 0;
		noteIndex=0;
		for(int i=0; i<notes.Count; i++){
			GameObject go = (GameObject)notes[i];
			NoteScript ns = go.GetComponent<NoteScript>();
			Invoke ("triggerAction", noteDelay);
			noteDelay += ns.value;
		}
	}

	void triggerAction() {
		GameObject go = (GameObject)notes[noteIndex];
		NoteScript ns = go.GetComponent<NoteScript>();
		Debug.Log(ns.pitch);
		Debug.Log(ns.value);
		GameObject burglar = GameObject.FindGameObjectWithTag("Character"+characterIndex.ToString());
		CharacterDriver cd = burglar.GetComponent<CharacterDriver>();


		cd.animate (ns.pitch, ns.value);
		//get character from global script/looking at tags and call action method
		//character.playAction(b.pitch, b.value);
		noteIndex++;
		if (noteIndex == notes.Count){
			cd.playMode = false;
		}
		else{
			cd.playMode = true;
		}
	}

	void OnGUI(){
		//Hacky position, change later
		//GUILayout.BeginArea(new Rect(Screen.width / 4, Screen.height / 2 , Screen.width /2, 200));
		GUILayout.BeginArea(new Rect(50, 500, 200, 200));
		
		newVal = GUILayout.TextField (newVal);
		newPitch = GUILayout.TextField (newPitch);
		if (GUILayout.Button("Add Note"))
		{
			GameObject note = (GameObject)Instantiate (Resources.Load ("Note"));
			NoteScript ns = note.GetComponent<NoteScript>();
			ns.value = 8/float.Parse(newVal);
			ns.pitch = newPitch;
			note.transform.localScale = new Vector3(ns.value, 1, 1);
			note.transform.position = new Vector3(notePos,0,-10);
			notePos += ns.value;

			newVal = "Note Length";
			newPitch = "Pitch";

			notes.Add (note);

		}
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
