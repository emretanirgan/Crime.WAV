using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {

	public float[] initialPositions; 
	GameObject targetObj;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnGUI(){
		//Hacky position, change later
		//GUILayout.BeginArea(new Rect(Screen.width / 4, Screen.height / 2 , Screen.width /2, 200));
		GUILayout.BeginArea(new Rect(20, 3.5f * Screen.height/ 4, 100, 200));

		
		if (GUILayout.Button("Play"))
		{

			/*for (int i = 0; i< 4; ++i)
			{
				GameObject[] go = GameObject.FindGameObjectsWithTag("placedNote"+i.ToString());
				if(go.Length > 0)
				{
					GameObject b = GameObject.FindGameObjectWithTag("Character"+i.ToString());
					CharacterDriver c = b.GetComponent<CharacterDriver>();
					c.playMode = true;
				}
			}*/
			GameObject[] go = GameObject.FindGameObjectsWithTag("noteRow");
			for (int i = 0; i< 4; ++i)
			{
				NoteRowScript ns = go[i].GetComponent<NoteRowScript>();
				ns.moveChar = true;
				/*if(go.Length > 0)
				{
					GameObject b = GameObject.FindGameObjectWithTag("Character"+i.ToString());
					CharacterDriver c = b.GetComponent<CharacterDriver>();
					c.playMode = true;
				}*/
			}

		}
		GUILayout.EndArea ();
	}
}
