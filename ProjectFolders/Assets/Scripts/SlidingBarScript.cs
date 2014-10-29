using UnityEngine;
using System.Collections;

public class SlidingBarScript : MonoBehaviour {

	public bool moveMode = false;
	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (moveMode == true){
			Vector3 pos = gameObject.transform.position;
			gameObject.transform.position = new Vector3(pos.x + speed, pos.y, pos.z);
			if (gameObject.transform.position.x >= 15) {
				gameObject.transform.position = new Vector3(-15, pos.y, pos.z);
			}
		}
	}
}
