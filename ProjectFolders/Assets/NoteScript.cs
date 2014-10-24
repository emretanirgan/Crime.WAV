using UnityEngine;
using System.Collections;

public class NoteScript : MonoBehaviour {

	public GameObject targetBurglar; 
	public float value;
	public string pitch;
	int number;
	// Use this for initialization
	public NoteScript(float v, string p, int n){
		value = v;
		pitch = p;
		number = n;
	}
	private Vector3 screenPoint;
	private Vector3 offset;
	
	private GameObject copyObject; 


	ArrayList notes;

	int noteIndex;

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

	void OnMouseUp()
	{
		GameObject targetObj0 = GameObject.FindGameObjectWithTag("targetPos0");
		GameObject targetObj1 = GameObject.FindGameObjectWithTag("targetPos1");
		GameObject targetObj2 = GameObject.FindGameObjectWithTag("targetPos2");
		GameObject targetObj3 = GameObject.FindGameObjectWithTag("targetPos3");
		
		float gridCubeWidth = 1.0f, gridCubeHeight = 0.75f;
		
		Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		float posX = Mathf.Round(gameObject.transform.position.x/ gridCubeWidth) * gridCubeWidth ; 
		float posY = Mathf.Round (gameObject.transform.position.y/gridCubeHeight) * gridCubeHeight;
		
		
		//Check there is no object in position. If there is destroy 
		Vector3 checkPosition = new Vector3 (posX, posY, targetObj0.transform.position.z);
		//Debug.Log (checkPosition);
		GameObject[] placedObjects = GameObject.FindGameObjectsWithTag("Note");
		
		foreach(GameObject current in placedObjects)
		{
			if(current.transform.position.x == checkPosition.x && current.transform.position.y == checkPosition.y)
			{	
				Destroy (gameObject);
			}
		}
		
		if (!targetObj0.collider.bounds.Contains(checkPosition) && !targetObj1.collider.bounds.Contains(checkPosition)
		    && !targetObj2.collider.bounds.Contains(checkPosition) && !targetObj3.collider.bounds.Contains(checkPosition)) {
			Destroy (gameObject);
		}
		
		gameObject.transform.position = new Vector3 (posX, posY, gameObject.transform.position.z);
		if(gameObject.transform.localScale.x == 1.0f)
			value = 16;
		else if(gameObject.transform.localScale.x == 2.0f)
			value = 8;
		else if(gameObject.transform.localScale.x == 4.0f)
			value = 4;
		if (posY == 0.75f || posY == -1.5f || posY == -3.75f || posY == -6.0f)
			pitch = "high";
		else if(posY == 0 || posY == -2.25f || posY == -4.5f || posY == -6.75f)
			pitch = "mid";
		else if (posY == -0.75f || posY == -3.0f || posY == -5.25f || posY == -7.5f)
			pitch = "low";


		if (targetObj0.collider.bounds.Contains(checkPosition))
			gameObject.tag = "placedNote0";
		else if (targetObj1.collider.bounds.Contains(checkPosition))
			gameObject.tag = "placedNote1";
		else if (targetObj2.collider.bounds.Contains(checkPosition))
			gameObject.tag = "placedNote2";
		else if (targetObj3.collider.bounds.Contains(checkPosition))
			gameObject.tag = "placedNote3";
		//Debug.Log (gameObject.tag);

	}
	void OnMouseDown()
	{
		//HARDCODED
		Vector3 positionOfBlockUI = new Vector3 (-20.0f, -2.0f, -4.0f);
		Vector3 positionOfBlockUI2 = new Vector3 (-20.0f, -1.0f, -4.0f);
		Vector3 positionOfBlockUI3 = new Vector3 (-20.0f, -3.0f, -4.0f);

		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		

		if ((gameObject.transform.position == positionOfBlockUI) || (gameObject.transform.position == positionOfBlockUI2)
		    || gameObject.transform.position == positionOfBlockUI3)
		{
			copyObject = Instantiate (gameObject, transform.position, transform.rotation) as GameObject; 
		}
	}
	
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
	
}
