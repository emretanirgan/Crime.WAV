using UnityEngine;
using System.Collections;

public class joey_test_scene_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel("joey_test-scene");
		}
	}


}
