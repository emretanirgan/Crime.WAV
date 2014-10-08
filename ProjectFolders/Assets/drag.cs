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


	// Use this for initialization
	void Start () {
		//targetObj.rigidbody.isKinematic = true;
	
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
		gameObject.transform.position = new Vector3(targetObj.transform.position.x,
		                                            targetObj.transform.position.y,
		                                            targetObj.transform.position.z);
		gameObject.rigidbody.isKinematic = true;
		Debug.Log ("COLLISION");
		
	}
	
	void OnMouseDown()
	{
		//drag = true;

		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		//initialPos = gameObject.transform.position; 
		copyObject = Instantiate (gameObject, transform.position, transform.rotation) as GameObject; 
	
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
