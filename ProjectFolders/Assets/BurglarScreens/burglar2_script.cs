using UnityEngine;
using System.Collections;

public class burglar2_script : MonoBehaviour {
	public Texture burglarImage; 
	
	Rect imagePos1 = new Rect (10, -100 , 100, 300);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI (){
		
		GUILayout.BeginArea (new Rect (Screen.width / 2-50, Screen.height / 2 - 200, Screen.width - 10, 200));
		
		GUILayout.Label ("BURGLAR 2", GUILayout.Width (200)); 
		
		GUILayout.EndArea ();
		
		Rect imagePos1 = new Rect (Screen.width / 2 - 75 , Screen.height / 2 - 150 , 
		                           burglarImage.width / 4, burglarImage.height / 4);
		GUI.Box (imagePos1, new GUIContent (burglarImage));

		GUILayout.BeginArea (new Rect (Screen.width / 2 - 75 + burglarImage.width / 3, Screen.height / 2 - 150, Screen.width - 10, 200));
		
		GUILayout.Label ("High Note: Punch", GUILayout.Width (200)); 
		GUILayout.Label ("Middle Note: Run", GUILayout.Width (200)); 
		GUILayout.Label ("Low Note: Kick", GUILayout.Width (200)); 
		
		GUILayout.EndArea ();

		GUILayout.BeginArea(new Rect(Screen.width / 2 - 75, Screen.height / 2 + 150, burglarImage.width / 4, 200));
		
		if (GUILayout.Button("Back"))
		{
			Application.LoadLevel("meet_the_burglars_scene");
		}
		
		
		GUILayout.EndArea();
	}
}