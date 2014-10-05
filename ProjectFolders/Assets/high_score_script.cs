using UnityEngine;
using System.Collections;

public class high_score_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){

		GUILayout.BeginArea (new Rect (Screen.width / 2-50, Screen.height / 2 - 100, Screen.width - 10, 200));
		
		GUILayout.Label ("HIGH SCORE", GUILayout.Width (200)); 
		
		GUILayout.EndArea ();
		
		
		GUILayout.BeginArea(new Rect(10, Screen.height / 2 - 50, Screen.width -10, 200));
		
		GUILayout.BeginVertical (); 
		GUILayout.BeginHorizontal ();
		
		GUILayout.Label ("Name:", GUILayout.Width (200)); 
		GUILayout.Label ("Score:", GUILayout.Width (200));
		
		GUILayout.EndHorizontal (); 
		
		for (int m = 1; m < 6; m++) {
			GUILayout.BeginHorizontal ();
			
			GUILayout.Label (getName (m), GUILayout.Width (200)); 
			GUILayout.Label (getScore (m), GUILayout.Width (200));
			
			GUILayout.EndHorizontal ();
		}
		
		GUILayout.EndVertical (); 
		
		
		// Load the main scene
		// The scene needs to be added into build setting to be loaded!
		if (GUILayout.Button("Menu"))
		{
			Application.LoadLevel("main_menu_scene");
		}
		
		GUILayout.EndArea();
	}
	
	string getScore(int i){
		return PlayerPrefs.GetInt ("Score" + i).ToString (); 
	}
	
	string getName(int i){
		return PlayerPrefs.GetString ("Name" + i); 
	}
	
	void AddScore(){
		int oldScore; 
		string oldName; 
		
		int newScore = PlayerPrefs.GetInt ("currentScore");
		string newName = PlayerPrefs.GetString ("currentName");
		
		for (int i = 1; i < 6; i++) {
			if (PlayerPrefs.GetInt ("currentScore") > PlayerPrefs.GetInt ("Score" + i)) {
				
				oldScore = PlayerPrefs.GetInt ("Score" + i);
				oldName = PlayerPrefs.GetString ("Name" + i); 
				
				PlayerPrefs.SetInt ("Score" + i, newScore);
				PlayerPrefs.SetString ("Name" + i, newName); 
				
				newScore = oldScore; 
				newName = oldName;
				
			} else {
				PlayerPrefs.SetInt ("Score" + i, newScore); 
				PlayerPrefs.SetString ("Name" + i, newName); 
				
				newScore = 0; 
				newName = ""; 
			}
			Debug.Log (PlayerPrefs.GetString ("Score" + i)); 
			
			PlayerPrefs.Save (); 
		}
	}
}
