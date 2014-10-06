using UnityEngine;
using System.Collections;

public class meet_the_burglars_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		
		GUILayout.BeginArea (new Rect (Screen.width / 2-50, Screen.height / 2 - 100, Screen.width - 10, 200));
		
		GUILayout.Label ("MEET THE BURGLARS", GUILayout.Width (200)); 
		
		GUILayout.EndArea ();
	
		GUILayout.BeginArea(new Rect(Screen.width / 4, Screen.height / 2 , Screen.width /2, 200));
	// Load the main scene
	// The scene needs to be added into build setting to be loaded!
		if (GUILayout.Button("Burglar 1"))
		{
			Application.LoadLevel("burglar1_scene");
		}
		
		if (GUILayout.Button("Burglar 2"))
		{
			Application.LoadLevel ("burglar2_scene");
		}
		if (GUILayout.Button("Burglar 3"))
		{
			Application.LoadLevel ("burglar3_scene");
		}
		
		if (GUILayout.Button("Burglar 4"))
		{
			Application.LoadLevel ("burglar4_scene");
		}

		if (GUILayout.Button("Menu"))
		{
			Application.LoadLevel("main_menu_scene");
		}
		
		
		GUILayout.EndArea();
	}
}
