using UnityEngine;
using System.Collections;

public class NoteScript : MonoBehaviour {

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
	Vector3[] initXPos = new Vector3[16];
	Vector3[] finalXPos = new Vector3[16];
	Vector3 notePos = new Vector3 (-9.0f, 0.1f, -4.0f);
	


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
		GameObject targetObj = GameObject.FindGameObjectWithTag("targetPos");
		
		float gridCubeWidth = 1.0f, gridCubeHeight = 0.75f;
		
		Vector3 mouseScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
		
		float posX = Mathf.Round(gameObject.transform.position.x/ gridCubeWidth) * gridCubeWidth ; 
		float posY = Mathf.Round (gameObject.transform.position.y/gridCubeHeight) * gridCubeHeight;
		
		
		//Check there is no object in position. If there is destroy 
		Vector3 checkPosition = new Vector3 (posX, posY, targetObj.transform.position.z);
		GameObject[] placedObjects = GameObject.FindGameObjectsWithTag("Note");
		
		foreach(GameObject current in placedObjects)
		{
			if(current.transform.position.x == checkPosition.x && current.transform.position.y == checkPosition.y)
			{	
				Destroy (gameObject);
			}
		}
		
		if (!targetObj.collider.bounds.Contains(checkPosition)) {
			Destroy (gameObject);
		}
		
		gameObject.transform.position = new Vector3 (posX, posY, gameObject.transform.position.z);
		if(gameObject.transform.localScale.x == 1.0f)
			value = 4;
		else if(gameObject.transform.localScale.x == 2.0f)
			value = 8;
		else if(gameObject.transform.localScale.x == 4.0f)
			value = 16;
		if (posY == 0.75f)
			pitch = "high";
		else if(posY == 0)
			pitch = "mid";
		else if (posY == -0.75f)
			pitch = "low";
		gameObject.tag = "placedNote";


	}
	void OnMouseDown()
	{
		//HARDCODED
		Vector3 positionOfBlockUI = new Vector3 (-9.5f, 2.0f, -4.0f);
		Vector3 positionOfBlockUI2 = new Vector3 (-8.0f, 2.0f, -4.0f);
		Vector3 positionOfBlockUI3 = new Vector3 (-5.5f, 2.0f, -4.0f);

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
