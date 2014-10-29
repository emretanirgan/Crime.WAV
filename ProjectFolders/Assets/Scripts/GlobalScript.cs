using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {

	public float[] initialPositions; 
	GameObject targetObj;
	public GUIStyle style;
	public Font font;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

	/*	lives = PlayerPrefs.GetInt ("currentLives");
		score = PlayerPrefs.GetInt ("currentScore");
		level = PlayerPrefs.GetInt ("currentLevel");
	*/
	}

	void OnGUI(){

		style.font = font; 
		style.fontSize = 30;



		GUILayout.BeginArea(new Rect(20, 3.3f * Screen.height/ 4, 200, 200));

		GUILayout.BeginVertical (); 


		if (GUILayout.Button("Listen", style))
		{
			//ADDDDDDDDDDD
			GameObject[] go = GameObject.FindGameObjectsWithTag("noteRow");
			for (int i = 0; i< 4; ++i)
			{
				NoteRowScript ns = go[i].GetComponent<NoteRowScript>();
				ns.listenNotes = true;
			}
		}
		
		if (GUILayout.Button("Play", style))
		{

			/*for (int i = 0; i< 4; ++i)
			{
				GameObject[] go = GameObject.FindGameObjectsWithTag("placedNote"+i.ToString());
				if(go.Length > 0)
				{
					GameObject b = GameObject.FindGameObjectWithTag("Character"+i.ToString());
					CharacterDriver c = b.GetComponent<CharacterDriver>();
					c.playMode = true;
				}
			}*/
			GameObject[] go = GameObject.FindGameObjectsWithTag("noteRow");
			for (int i = 0; i< 4; ++i)
			{
				NoteRowScript ns = go[i].GetComponent<NoteRowScript>();
				ns.moveCharBegin = true;
				/*if(go.Length > 0)
				{
					GameObject b = GameObject.FindGameObjectWithTag("Character"+i.ToString());
					CharacterDriver c = b.GetComponent<CharacterDriver>();
					c.playMode = true;
				}*/
			}

		}
		if (GUILayout.Button("Quit", style))
		{
			Application.LoadLevel("main_menu_scene");
		}

 

		GUILayout.EndVertical (); 
		GUILayout.EndArea ();
	}
}
