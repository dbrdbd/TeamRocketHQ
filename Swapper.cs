using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {
	
	static void Swap(GameObject object1, GameObject object2)
	{
		Vector3 tempPosition = object1.transform.position;
		object1.transform.position = object2.transform.position;
		object2.transform.position = tempPosition;
	}
	
	void Update()
	{
		GameObject object1 = GameObject.Find("25"), object2;
		if (Input.GetButtonDown("W"))
			object2 = GameObject.Find("18");
		else if (Input.GetButtonDown("A"))
			object2 = GameObject.Find("24");
		else if (Input.GetButtonDown("S"))
			object2 = GameObject.Find("32");
		else if (Input.GetButtonDown("D"))
			object2 = GameObject.Find("26")
		
		Swap(object1, object2);
	}

}
