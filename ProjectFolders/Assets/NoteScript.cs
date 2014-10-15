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


/*		notes = new ArrayList();

		noteIndex = 0;
		
		//Remove once block placing UI is implemented
		GameObject[] blocks = GameObject.FindGameObjectsWithTag("Note");
		for(int i=0; i<blocks.Length; i++){
			notes.Add (blocks[i]);
			//Debug.Log ("notes");
			//Debug.Log(i);
		}

*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp()
	{
		GameObject targetObj = GameObject.FindGameObjectWithTag("targetPos");
		
		float gridCubeWidth = 1.0f, gridCubeHeight = 0.25f;

		float changedPosX = gameObject.transform.position.x + gameObject.transform.localScale.x/2.0f; 
		Debug.Log (changedPosX); 
		Debug.Log (gameObject.transform.position.x);
		Debug.Log (changedPosX);
		
		float posX = Mathf.Round(gameObject.transform.position.x/ gridCubeWidth) * gridCubeWidth ; 
		float posY = targetObj.transform.position.y;

		gameObject.transform.position = new Vector3 (posX, posY, gameObject.transform.position.z); 



	}
	void OnMouseDown()
	{
		//HARDCODED
		Vector3 positionOfBlockUI = new Vector3 (-11.5f, 0.1f, -4.0f);
		Vector3 positionOfBlockUI2 = new Vector3 (-11.5f, 1.3f, -4.0f);
		Vector3 positionOfBlockUI3 = new Vector3 (-13.5f, 2.6f, -4.0f);
		Vector3 positionOfBlockUI4 = new Vector3 (-14.5f, 3.9f, -4.0f);
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		

		if ((gameObject.transform.position == positionOfBlockUI) || (gameObject.transform.position == positionOfBlockUI2)
		    || gameObject.transform.position == positionOfBlockUI3 || gameObject.transform.position == positionOfBlockUI4)
		{
			//GameObject note = (GameObject)Instantiate (Resources.Load ("Note"));
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
