using UnityEngine;
using System.Collections;

public class NoteRowScript : MonoBehaviour {

	public ArrayList notes;
	public int noteIndex;
	public int characterIndex = -1;

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
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("space")){
			playNotes ();
		}
	}

	void playNotes() {
		float noteDelay = 0;
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
		//get character from global script/looking at tags and call action method
		//character.playAction(b.pitch, b.value);
		noteIndex++;
	}
}
