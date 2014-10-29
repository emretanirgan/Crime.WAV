using UnityEngine;
using System.Collections;

public class select_level_script : MonoBehaviour {

	public GUIStyle style; 
	public Font font; 
	public Texture texture; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){

		style.font = font;



	
		GUILayout.BeginArea(new Rect(Screen.width / 3, Screen.height / 2 , Screen.width /2, 200));
	//	GUILayout.BeginVertical ();

		if (GUILayout.Button("1", style))
		{
			Application.LoadLevel("joey_test-scene");
		}
	/*	if (GUILayout.Button ("2", style)) {
				}
		if (GUILayout.Button ("3", style)) {
				}

		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("?", style)) {
				}
		if (GUILayout.Button ("?", style)) {
				}
		if (GUILayout.Button ("?", style)) {
				}
		GUILayout.EndHorizontal ();
		GUILayout.EndVertical ();*/
		GUILayout.EndArea();

		GUILayout.BeginArea(new Rect(0.9f * Screen.width / 2, 1.5f * Screen.height / 2 , Screen.width /2, 200));

		if (GUILayout.Button("Main Menu", style))
		{
			Application.LoadLevel("main_menu_scene");
		}
		

		GUILayout.EndArea();
	}
}
