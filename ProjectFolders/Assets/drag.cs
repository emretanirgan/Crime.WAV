using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(BoxCollider))]

public class drag : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	//public GameObject note; 
	//private Vector3 initialPos; 
	private GameObject copyObject; 
	//public GameObject targetObj;

	Vector3[] initXPos = new Vector3[16];
	Vector3[] finalXPos = new Vector3[16];
	int noteNum = 0; 

	GameObject targetObj;
	// Use this for initialization

	void Start () {
		//targetObj.rigidbody.isKinematic = true;
		targetObj = GameObject.FindGameObjectWithTag("targetPos");
		Vector3 targetPos = targetObj.transform.position;
		float xScale = targetObj.transform.localScale.x;
		float discretization = 14 / 16.0f; 

		//Create array of initial positions
		for (int i = 0; i < 16; i++)

		{
			
		/*	Debug.Log("intial");
			initXPos[i] = new Vector3(targetPos.x - xScale/2.0f + i*discretization, targetPos.y, 
			                          targetPos.z);
			Debug.Log (initXPos[i]);
			finalXPos[i] = new Vector3(initXPos[i].x + discretization, targetPos.y, 
			                           targetPos.z);
		*/
			initXPos[i] = new Vector3(targetPos.x - 14/2.0f + i*discretization, targetPos.y, 
			                          targetPos.z);
			//Debug.Log (initXPos[i]);
			finalXPos[i] = new Vector3(initXPos[i].x + discretization, targetPos.y, 
			                           targetPos.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnTriggerEnter(Collision collision)
	{
		//the Collision contains a lot of info, but it's the colliding 
		//object we're most interested in. 
		Collider collider = collision.collider; 
		
		if (collider.CompareTag ("targetPos")) {
			

			gameObject.transform.position = new Vector3(targetObj.transform.position.x,
			                                            targetObj.transform.position.y,
			                                            targetObj.transform.position.z);
			gameObject.rigidbody.isKinematic = true;
			Debug.Log ("COLLISION");
		}
	}*/
	/*Vector3 SnapToPosition(Vector3 Position)
	{
		GameObject targetObj = GameObject.FindGameObjectsWithTag("targetPos");

	/*	//  get grid size from the texture tiling
		Vector2 GridSize = grid.renderer.material.mainTextureScale;
		
		//  get position on the quad from -0.5...0.5 (regardless of scale)
		Vector3 gridPosition = grid.transform.InverseTransformPoint( Position );
		//  scale up to a number on the grid, round the number to a whole number, then put back to local size
		gridPosition.x = Mathf.Round( gridPosition.x * GridSize.x ) / GridSize.x;
		gridPosition.y = Mathf.Round( gridPosition.y * GridSize.y ) / GridSize.y;
		
		//  don't go out of bounds
		gridPosition.x = Mathf.Min ( 0.5f, Mathf.Max (-0.5f, gridPosition.x) );
		gridPosition.y = Mathf.Min ( 0.5f, Mathf.Max (-0.5f, gridPosition.y) );
		
		Position = targetObj.transform.TransformPoint( gridPosition );
		return Position;
	}*/
	
	void OnMouseUp()
	{
		GameObject targetObj = GameObject.FindGameObjectWithTag("targetPos");

		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;


		transform.localScale = new Vector3(1, 1, 1);
		Debug.Log (noteNum);
		transform.position = new Vector3(initXPos[noteNum].x,targetObj.transform.position.y, 
		                                 targetObj.transform.position.z);
		noteNum += 1;
		

	/*	GameObject note = (GameObject)Instantiate (Resources.Load ("Note"));
		NoteScript ns = note.GetComponent<NoteScript>();
		ns.value = 8/float.Parse(newVal);
		ns.pitch = newPitch;
		note.transform.localScale = new Vector3(ns.value, 1, 1);
		note.transform.position = new Vector3(notePos,0,-10);
		notePos += ns.value;
		
		newVal = "Note Length";
		newPitch = "Pitch";
		
		notes.Add (note);*/

/*		for (int i = 0; i < 16; i++)
		{
			//Debug.Log("fina");
			//Debug.Log (curPosition);

			Vector3 initPosWorld = initXPos[i];

			//Debug.Log(initPosWorld);
			//	Debug.Log (transform.position.x);
			if((curPosition.x - initPosWorld.x) < 0.1f)
			{
				//CHANGE SCALE DEPENIDNG ON PITCH
				transform.localScale = new Vector3(1, 1, 1);
				transform.position = new Vector3(initPosWorld.x, targetObj.transform.position.y, 
				                                 targetObj.transform.position.z);
				Debug.Log ("SSDS");

			}

		}*/




	//	note.transform.localScale = new Vector3(ns.value, 1, 1);
	//	note.transform.position = new Vector3(notePos,0,-10);
	//	notePos += ns.value;


	//	gameObject.transform.position = new Vector3(targetObj.transform.position.x,
		                                     //       targetObj.transform.position.y,
		                                      //      targetObj.transform.position.z);
		gameObject.rigidbody.isKinematic = true;

		
	}
	
	void OnMouseDown()
	{
		//drag = true;
		//HARDCODED: CHANGE THIS LATER
		Vector3 positionOfBlockUI = new Vector3 (-9.0f, 0.1f, -4.0f);
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		//initialPos = gameObject.transform.position; 

		if (gameObject.transform.position == positionOfBlockUI)
		{
			copyObject = Instantiate (gameObject, transform.position, transform.rotation) as GameObject; 
		}
	}
	
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;

		/*if (Mathf.Abs (copyObject.transform.position.x - targetObj.transform.position.x)
		    < 1.5)
		{
			if (Mathf.Abs (copyObject.transform.position.y - targetObj.transform.position.y)
			    < 1.5)
			{
				copyObject.transform.position =  new Vector3(targetObj.transform.position.x,
				                                             targetObj.transform.position.y,
				                                             targetObj.transform.position.z);
				//copyObject.transform.position.y = -9.0f;
				Debug.Log (copyObject.transform.position.x);
				Debug.Log (copyObject.transform.position.y);
				
			}
		}*/

		//if (drag)
		//{
			//dragObject(); 
		//}
	}

	/*void dragObject()
	{
		Vector3 mousePos = Input.mousePosition; 

		if (3.8 <= mousePos.x && mousePos.x <= 4.2)
		{
			if (-9.2 <= mousePos.y && mousePos.y <= -8.8)
			{
				copyObject.transform.position =  new Vector3(4.0f, -9.0f, screenPoint.z);
				//copyObject.transform.position.y = -9.0f;
				Debug.Log (copyObject.transform.position.x);
				Debug.Log (copyObject.transform.position.y);

			}
		}
	}*/
}
