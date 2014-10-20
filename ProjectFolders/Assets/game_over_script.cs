using UnityEngine;
using System.Collections;

public class game_over_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUILayout.BeginArea (new Rect (Screen.width / 2-50, Screen.height / 2 - 100, Screen.width - 10, 200));
		
		GUILayout.BeginVertical ();
		
		GUILayout.Label ("GAME OVER", GUILayout.Width (200)); 
		
	//	GUILayout.Label ("Your Score: ", GUILayout.Width (200));
		
		GUILayout.EndVertical ();
		
		GUILayout.EndArea ();
		
	//	GUILayout.BeginArea (new Rect (10, Screen.height / 2 - 25, Screen.width - 10, 200));
		
	//	GUILayout.Label ("Enter Name To Save Score: ", GUILayout.Width (200));
		
	//	GUILayout.EndArea ();

		GUILayout.BeginArea(new Rect(Screen.width / 4, Screen.height / 2 , Screen.width /2, 200));

		if (GUILayout.Button("Menu"))
		{
			Application.LoadLevel("main_menu_scene");
		}
		
		if (GUILayout.Button ("High Scores")) {
			Application.LoadLevel ("high_score_scene"); 
		}
		
		GUILayout.EndArea();
	}
}
