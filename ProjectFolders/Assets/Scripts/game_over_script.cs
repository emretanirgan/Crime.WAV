using UnityEngine;
using System.Collections;

public class game_over_script : MonoBehaviour {

	public Font font;
	public GUIStyle style;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		style.font = font;
		GUILayout.BeginArea(new Rect(0.9f * Screen.width / 2, Screen.height / 2 , Screen.width /2, 200));

		if (GUILayout.Button("Menu", style))
		{
			Application.LoadLevel("main_menu_scene");
		}
		
		if (GUILayout.Button ("High Scores", style)) {
			Application.LoadLevel ("high_score_scene"); 
		}
		
		GUILayout.EndArea();
	}
}
