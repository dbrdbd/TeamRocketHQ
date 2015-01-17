using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {
	public GameObject object1, object2;
	public Vector3 temp;
	void Update()
	{
		object1 = GameObject.Find ("25");
		if (Input.GetButtonDown("W"))
		{
			object2 = GameObject.Find("18");
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
		}
			
		else if (Input.GetButtonDown("A"))
		{
			object2 = GameObject.Find("24");
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
		}
		else if (Input.GetButtonDown("S"))
		{
			object2 = GameObject.Find("32");
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
		}
		else if (Input.GetButtonDown("D"))
		{
			object2 = GameObject.Find("26");
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
		}
	}

}
