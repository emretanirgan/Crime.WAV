using UnityEngine;
using System.Collections;

public class meet_the_burglars_script : MonoBehaviour {
	public Texture burglarImage; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		
		GUILayout.BeginArea (new Rect (Screen.width / 2-50, Screen.height / 2 - 200, Screen.width - 10, 200));
		
		GUILayout.Label ("MEET THE BURGLARS", GUILayout.Width (200)); 
		
		GUILayout.EndArea ();

		Rect imagePos1 = new Rect (Screen.width / 2 - 250 , Screen.height / 2 - 150 , 
		                           burglarImage.width / 2, burglarImage.height / 2);
		GUI.Box (imagePos1, new GUIContent (burglarImage));
	
		GUILayout.BeginArea(new Rect(Screen.width / 2 - 250, Screen.height / 2 - 150 + burglarImage.height / 2,
		                             burglarImage.width / 8, 200));
	// Load the main scene
	// The scene needs to be added into build setting to be loaded!
		if (GUILayout.Button("Burglar 1"))
		{
			Application.LoadLevel("burglar1_scene");
		}

		GUILayout.EndArea ();

		GUILayout.BeginArea(new Rect(Screen.width / 2 - 250 + burglarImage.width / 8, Screen.height / 2 - 150 + burglarImage.height / 2,
		                             burglarImage.width / 8, 200));

		if (GUILayout.Button("Burglar 2"))
		{
			Application.LoadLevel ("burglar2_scene");
		}

		GUILayout.EndArea ();
		
		GUILayout.BeginArea(new Rect(Screen.width / 2 - 250 + 2*burglarImage.width / 8, Screen.height / 2 - 150 + burglarImage.height / 2,
		                             burglarImage.width / 8, 200));

		if (GUILayout.Button("Burglar 3"))
		{
			Application.LoadLevel ("burglar3_scene");
		}

		GUILayout.EndArea ();
		
		GUILayout.BeginArea(new Rect(Screen.width / 2 - 250 + 3*burglarImage.width / 8, Screen.height / 2 - 150 + burglarImage.height / 2,
		                             burglarImage.width / 8, 200));


		if (GUILayout.Button("Burglar 4"))
		{
			Application.LoadLevel ("burglar4_scene");
		}

		GUILayout.EndArea ();
		
		GUILayout.BeginArea(new Rect(Screen.width / 2 - 75, Screen.height / 2 + 150,
		                             burglarImage.width / 8, 200));

		if (GUILayout.Button("Menu"))
		{
			Application.LoadLevel("main_menu_scene");
		}
		
		
		GUILayout.EndArea();
	}
}
