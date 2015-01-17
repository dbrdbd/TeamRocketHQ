using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private const int SizeGrid = 7;
	//creates first grid - maybe make this  void Start() {} ?

	void Start () {

		int[ , ] GridList = new int[SizeGrid, SizeGrid];

		//initialize Grid to a series of numbers between 1 and 4
		for ( int i = 0; i < SizeGrid; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				GridList[i, j] = Random.Range (1, 5);
			}
		}

		//Call Random Generator to figure out which colored sphere to put where and place it there
		for ( int i = 0; i < SizeGrid; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				GameObject key = RandomGenerator( GridList[i, j] );
				key.transform.position = new Vector3( i, j, 0 );
			}
		}
	}

	//create a function that will calculate which color each sphere will be
	GameObject RandomGenerator ( int a ) {

		GameObject ans = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		
		if ( a == 1 )
			ans.renderer.material.color = Color.red;
		else if ( a == 2 )
			ans.renderer.material.color = Color.blue;
		else if ( a == 3 )
			ans.renderer.material.color = Color.green;
		else
			ans.renderer.material.color = Color.magenta;
		
		return ans;
	}
	/*
	void Start () {

		public int[] cList;
		public int[] cList2;
		
			
			int count = 0;
			int x = -3;
			int z = -3;
			
			while(x <= 3)
			{
				while(z<=3)
				{
					if (gridList[count] == 1)
					{
						var a = GameObject.CreatePrimitive(PrimitiveType.Sphere);
						a.transform.position = new Vector3(x,0,z);
						count++;
						z+=1;
					}
					else if (gridList[count] == 2)
					{
						var a = GameObject.CreatePrimitive(PrimitiveType.Cube);
						a.transform.position = new Vector3(x,0,z);
						count++;
						z+=1;
					}
					else if (gridList[count] == 3)
					{
						var a = GameObject.CreatePrimitive(PrimitiveType.Capsule);
						a.transform.position = new Vector3(x,0,z);
						count++;
						z+=1;
					}
					else if (gridList[count] == 4)
					{
						var a = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
						a.transform.position = new Vector3(x,0,z);
						count++;
						z+=1;
					}
				}
				z = -3;
				x+=1;
			}
		} */
	// Update is called once per frame
	void Update () {
	
	}
}
