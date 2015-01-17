using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {
	private GameObject object1, object2;
	private Vector3 temp;
	void Update()
	{
		object1 = GameObject.Find ("25");
		//print (object1);
		if (Input.GetKeyDown(KeyCode.W))
		{
			object2 = GameObject.Find("18");
			//print ("Object 2 position: " + object2.transform.position.ToString());
			temp = object1.transform.position;
			//print ("Temp: " + temp.ToString ());
			object1.transform.position = object2.transform.position;
			//print ("Object 1 Position: " + object1.transform.position.ToString ());
			object2.transform.position = temp;
			//print ("Object 2 Position: " + object2.transform.position.ToString ());
		}
			
		else if (Input.GetKeyDown(KeyCode.A))
		{
			object2 = GameObject.Find("24");
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			object2 = GameObject.Find("32");
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			object2 = GameObject.Find("26");
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
		}
	}

}
