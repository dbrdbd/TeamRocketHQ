using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {

	void Start()
	{
		
	}
	
	void Swap()
	{
		GameObject object1;
		GameObject object2;
		Vector3 tempPosition = object1.transform.position;
		object1.transform.position = object2.transform.position;
		object2.transform.position = tempPosition;
	}
}
