﻿using UnityEngine;
using System.Collections;

public class guitext_script : MonoBehaviour {

	
	int score; 
	float lives; 
	int level;
	// Use this for initialization
	void Start () {
		lives = PlayerPrefs.GetFloat ("currentLives");
		score = PlayerPrefs.GetInt ("currentScore");
		level = PlayerPrefs.GetInt ("currentLevel");

	}
	
	// Update is called once per frame
	void Update () {
		lives = PlayerPrefs.GetFloat ("currentLives");
		score = PlayerPrefs.GetInt ("currentScore");
		level = PlayerPrefs.GetInt ("currentLevel");
		
	}

	void OnGUI () 
	{
		guiText.fontSize = 30;

		//string text1 = "Level: " + PlayerPrefs.GetInt ("currentLevel").ToString ();
		//GUIStyle style = new GUIStyle ();
		//style.richText = true;
		//GUILayout.Label("<size=20>Level <color=black></color> </size>",style);
		//GUILayout.Label (text1, GUILayout.Width (100));

		guiText.text = "Level: " + PlayerPrefs.GetInt ("currentLevel").ToString () 
			+ "\n \nPoints: " + PlayerPrefs.GetInt ("currentScore").ToString ()
				+ "\n \nLives: " + PlayerPrefs.GetFloat ("currentLives").ToString () ;



	}
}
