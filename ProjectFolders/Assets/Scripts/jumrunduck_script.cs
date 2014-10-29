using UnityEngine;
using System.Collections;

public class jumrunduck_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Jump \nRun \nDuck" +
				"\n\nJump \nRun \nDuck"+
				"\n\nJump \nRun \nDuck"+
				"\n\nJump \nRun \nDuck";
		guiText.fontSize = 20;
	
	}
}
