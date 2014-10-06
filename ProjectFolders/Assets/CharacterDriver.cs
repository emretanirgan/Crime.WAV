using UnityEngine;
using System.Collections;

public class CharacterDriver : MonoBehaviour {
	public Block[] TestArray;
	// Use this for initialization
	void Start () {
		this.renderer.material.color = Color.white;
		Block a = new Block(1.0f,"hi");
		Block b = new Block(1.0f,"low");
		Block c = new Block(1.0f,"mid");
		TestArray = new Block[3];
		TestArray[0] = a;
		TestArray[1] = b;
		TestArray[2] = c;

		for(int i = 0; i < TestArray.Length; i++){
			switch(TestArray[i].pitch){
			case("mid"):
				this.renderer.material.color = Color.white;
				print("white");
				break;
			case("hi"):
				this.renderer.material.color = Color.yellow;
				print("yellow");
				break;
			case("low"):
				this.renderer.material.color = Color.blue;
				print("blue");
				break;
			default:
				break;
			}
			StartCoroutine(delay(TestArray[i].value));
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator delay(float t){
		yield return new WaitForSeconds(t*1000);
	}
}
