using UnityEngine;
using System.Collections;

public class high_score_script : MonoBehaviour {

	public GUIStyle style; 
	public Font font; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){

		style.font = font;
		style.fontSize = 30;
	
		GUILayout.BeginArea(new Rect(10, Screen.height / 2 , Screen.width -10, 200));
		
		GUILayout.BeginVertical (); 
		GUILayout.BeginHorizontal ();
		
		GUILayout.Label ("Name:", style); 
		GUILayout.Label ("Score:", style);
		
		GUILayout.EndHorizontal (); 
		
		for (int m = 1; m < 6; m++) {
			GUILayout.BeginHorizontal ();
			
			GUILayout.Label (getName (m), style); 
			GUILayout.Label (getScore (m),  style);
			
			GUILayout.EndHorizontal ();
		}
		
		GUILayout.EndVertical (); 
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(Screen.width / 2, 3.5f * Screen.height / 4.0f , Screen.width -10, 200));
		// Load the main scene
		// The scene needs to be added into build setting to be loaded!
		if (GUILayout.Button("Menu", style))
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
