using UnityEngine;
using System.Collections;

public class NoteRowScript : MonoBehaviour {

	public ArrayList notes;
	public int noteIndex;
	public int characterIndex = -1;
	public int viewLimit = 3;
	//If space is pressed, the character also moves with the music
	public bool moveChar = false;
//	public GameObject targetChar; 

	// Use this for initialization
	void Start () {
		notes = new ArrayList();
		noteIndex = 0;
		Invoke("uncheckLight", 0);
		//Loop the music
		InvokeRepeating("playNotes", 0, 8);

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
		GameObject[] go = GameObject.FindGameObjectsWithTag("placedNote"+characterIndex.ToString());
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

		GUILayout.BeginArea(new Rect(20, 3.5f * Screen.height/ 4 + 25, 100, 200));
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
