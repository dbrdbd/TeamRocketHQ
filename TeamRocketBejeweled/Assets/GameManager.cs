using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private const int SizeGrid = 7;
	private int Score = 0;
	private int[ , ] GridList = new int[ SizeGrid, SizeGrid ];
	private GameObject[ , ] cList = new GameObject[ SizeGrid, SizeGrid ];
	private int FinalTime = 180;

	//creates first grid
	void Start () {

		//initialize Grid to a series of numbers between 1 and 4
		for ( int i = 0; i < SizeGrid; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				GridList[i, j] = Random.Range (1, 9);
			}
		}

		//Call Random Generator to figure out which colored sphere to put where 
		//and place it there
		//also set up a name for each object in GridList via a number
		int counter = 1;

		for ( int i = 0; i < SizeGrid; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				GameObject key = RandomGenerator( GridList[i, j], counter );
				cList[ i, j ] = key;
				GridList[ i, j ] = counter;
				counter++;
				key.transform.position = new Vector3( i, j, 0 );
			}
		}
	}

	//create a function that will calculate which color each sphere will be
	GameObject RandomGenerator ( int a, int b ) {

		GameObject ans = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		
		if ( a == 1 )
			ans.renderer.material.color = Color.red;
		else if ( a == 2 )
			ans.renderer.material.color = Color.blue;
		else if ( a == 3 )
			ans.renderer.material.color = Color.green;
		else if ( a == 4 )
			ans.renderer.material.color = Color.magenta;
		else if ( a == 5 )
			ans.renderer.material.color = Color.gray;
		else if ( a == 6 )
			ans.renderer.material.color = Color.yellow;
		else if ( a == 7 )
			ans.renderer.material.color = Color.cyan;
		else
			ans.renderer.material.color = Color.white;

		ans.name = b.ToString();
		return ans;
	}

	//maybe call it update function?
/*	 void main () {
		while ( Time.realtimeSinceStartup <= FinalTime ) { //timer to check - game not longer than 3 min
			//movement function here
			//swap function here
			//destroy here
			//drop function
			//refill function here

			//increment points here
			Score += 300;

			FinalTime = 10;
		}

		//end with text of total points
		string FinalScore = Score;
		string End = "GAME OVER! \n Final Score: " + FinalScore;

		GUIText : End;
	} */
}
