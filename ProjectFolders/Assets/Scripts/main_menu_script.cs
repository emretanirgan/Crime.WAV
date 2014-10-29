using UnityEngine;
using System.Collections;

public class main_menu_script : MonoBehaviour {

	public Font font;
	public GUIStyle style;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){

		style.font = font;
		GUILayout.BeginArea(new Rect(0.9f * Screen.width / 2, Screen.height / 2 , Screen.width /2, 200));
		// Load the main scene
		// The scene needs to be added into build setting to be loaded!
		if (GUILayout.Button("New Game", style))
		{
			PlayerPrefs.SetInt ("currentLives", 4);
			PlayerPrefs.SetInt ("currentScore", 100);
			PlayerPrefs.SetInt ("currentLevel", 1);
			Application.LoadLevel("joey_test-scene");
		}
		if (GUILayout.Button("Select Level", style))
		{
			Application.LoadLevel ("select_level_scene");
		}
		if (GUILayout.Button("High Score", style))
		{
			Application.LoadLevel ("high_score_scene");
		}
		/*if (GUILayout.Button("Meet The Burglars", style))
		{
			Application.LoadLevel ("meet_the_burglars_scene");
		}
		*/
		if (GUILayout.Button("Exit", style))
		{
			Application.Quit();
			Debug.Log ("Application.Quit() only works in build, not in editor");
		}
		
		
		GUILayout.EndArea();

	}  
}


