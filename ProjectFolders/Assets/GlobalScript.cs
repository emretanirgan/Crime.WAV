using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {

	public float[] initialPositions; 
	GameObject targetObj;

	// Use this for initialization
	void Start () {
		initialPositions = new float[16];
		
		targetObj = GameObject.FindGameObjectWithTag("targetPos");
		Vector3 targetPos = targetObj.transform.position;
		float xScale = targetObj.transform.localScale.x;
		float discretization = 14 / 16.0f; 

		//Create array of initial positions
		for (int i = 0; i < 16; i++)	
		{			
			initialPositions[i] = targetPos.x - 14/2.0f + i*discretization;
			Debug.Log (initialPositions[i]);
			//	finalXPos[i] = new Vector3(initXPos[i].x + discretization, targetPos.y, 
			//	                           targetPos.z);
			/*	initXPos[i] = new Vector3(targetPos.x - 14/2.0f + i*discretization, targetPos.y, 
			                          targetPos.z);
			//Debug.Log (initXPos[i]);
			finalXPos[i] = new Vector3(initXPos[i].x + discretization, targetPos.y, 
			                           targetPos.z);
			                           */
		}
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
