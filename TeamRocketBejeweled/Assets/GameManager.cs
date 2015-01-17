using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private const int SizeGrid = 7;

	//creates first grid
	void Start () {

		int[ , ] GridList = new int[SizeGrid, SizeGrid];
		GameObject[ , ] cList = new GameObject[SizeGrid, SizeGrid];

		//initialize Grid to a series of numbers between 1 and 4
		for ( int i = 0; i < SizeGrid; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				GridList[i, j] = Random.Range (1, 5);
			}
		}

		//Call Random Generator to figure out which colored sphere to put where 
		//and place it there
		//also set up a name for each object in GridList via a number
		int counter = 1;

		for ( int i = 0; i < SizeGrid; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				GameObject key = RandomGenerator( GridList[i, j] );
				cList[ i, j ] = key;
				GridList[ i, j ] = counter;
				counter++;
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



	//ADD SWAP FUNCTION HERE WITH CHECKS

	//ADD DESTROY AND REPLACE HERE
	
	// Update is called once per frame
	void Update () {
		print ("In update function");
	}
}
