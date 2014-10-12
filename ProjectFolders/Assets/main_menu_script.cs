using UnityEngine;
using System.Collections;

public class main_menu_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		GUILayout.BeginArea (new Rect (Screen.width / 2-50, Screen.height / 2 - 100, Screen.width - 10, 200));
		
		GUILayout.Label ("Crime.WAV", GUILayout.Width (200)); 
		
		GUILayout.EndArea ();
		
		GUILayout.BeginArea(new Rect(Screen.width / 4, Screen.height / 2 , Screen.width /2, 200));
		// Load the main scene
		// The scene needs to be added into build setting to be loaded!
		if (GUILayout.Button("New Game"))
		{
			//Application.LoadLevel("play_scene");
			Application.LoadLevel("joey_test-scene");
		}
		if (GUILayout.Button("Select Level"))
		{
			Application.LoadLevel ("select_level_scene");
		}
		if (GUILayout.Button("High Score"))
		{
			Application.LoadLevel ("high_score_scene");
		}
		if (GUILayout.Button("Meet The Burglars"))
		{
			Application.LoadLevel ("meet_the_burglars_scene");
		}
		
		if (GUILayout.Button("Exit"))
		{
			Application.Quit();
			Debug.Log ("Application.Quit() only works in build, not in editor");
		}
		
		
		GUILayout.EndArea();
	}  
}


