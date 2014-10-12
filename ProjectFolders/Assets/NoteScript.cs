using UnityEngine;
using System.Collections;

public class NoteScript : MonoBehaviour {

	public float value;
	public string pitch;
	// Use this for initialization
	public NoteScript(float v, string p){
		value = v;
		pitch = p;
	}
	
	void Start () {
		if (pitch == "mid"){
			gameObject.renderer.material.color = Color.white;
		}
		else if (pitch == "low"){
			gameObject.renderer.material.color = Color.blue;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
