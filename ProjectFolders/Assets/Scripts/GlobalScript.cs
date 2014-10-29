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


		GUILayout.BeginArea(new Rect(20, 3.5f * Screen.height/ 4, 100, 200));

		GUILayout.BeginVertical (); 

		if (GUILayout.Button("Quit", style))
		{
			Application.LoadLevel("main_menu_scene");
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

 

		GUILayout.EndVertical (); 
		GUILayout.EndArea ();
	}
}
