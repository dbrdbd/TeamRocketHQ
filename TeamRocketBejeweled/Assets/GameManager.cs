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
		ReShape();
	}

	void ReShape() {

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

	void CheckDestroy(int var1, int var2)
	{
		bool threeLeft = ((cList [var1, var2] == cList [var1 - 1, var2]) && (cList [var1, var2] == cList [var1 - 2, var2]));
		bool threeRight = ((cList[var1, var2] == cList[var1 + 1, var2]) && (cList[var1, var2] == cList[var1+2, var2]));
		bool threeUp = ((cList[var1, var2] == cList[var1, var2+1]) && (cList[var1, var2] == cList[var1, var2+2]));
		bool threeDown = ((cList[var1, var2] == cList[var1, var2-1]) && (cList[var1, var2] == cList[var1, var2-2]));
		bool threeMidVert = ((cList[var1, var2] == cList[var1, var2+1]) && (cList[var1, var2] == cList[var1, var2-1]));
		bool threeMidHor = ((cList[var1, var2] == cList[var1 + 1, var2]) && (cList[var1, var2] == cList[var1-1, var2]));
		
		bool fourUp = ((cList[var1, var2] == cList[var1, var2+1]) && (cList[var1, var2] == cList[var1, var2+2]) && (cList[var1, var2] == cList[var1, var2-1]));
		bool fourDown = ((cList[var1, var2] == cList[var1, var2-1]) && (cList[var1, var2] == cList[var1, var2-2]) && (cList[var1, var2] == cList[var1, var2+1]));
		bool fourRight = ((cList[var1, var2] == cList[var1+1, var2]) && (cList[var1, var2] == cList[var1+2, var2]) && (cList[var1, var2] == cList[var1-1, var2]));
		bool fourLeft = ((cList[var1, var2] == cList[var1-1, var2]) && (cList[var1, var2] == cList[var1-2, var2]) && (cList[var1, var2] == cList[var1+1, var2]));
		
		bool fiveVert = ((cList[var1, var2] == cList[var1, var2+1]) && (cList[var1, var2] == cList[var1, var2+2]) && (cList[var1, var2] == cList[var1, var2-1]) && (cList[var1, var2] == cList[var1, var2-2]));
		bool fiveHor = ((cList[var1, var2] == cList[var1+1, var2]) && (cList[var1, var2] == cList[var1+2, var2]) && (cList[var1, var2] == cList[var1-1, var2]) && (cList[var1, var2] == cList[var1-2, var2]));
		
		if((threeLeft || threeRight || threeUp || threeDown || threeMidHor || threeMidVert) == true)   
		{
			if( Event.current.Equals (Event.KeyboardEvent ("[enter]"))/*Movement is up*/ )
			{
				if((threeUp && fiveHor) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
				}
				else if ((threeUp && fourRight) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
				}
				else if((threeUp && fourLeft) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1+1, var2], 5f);
				}
				else if((threeUp && threeMidHor) == true)
				{
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((fiveHor) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
				}
				else if((fourRight) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
				}
				else if((fourLeft)== true)
				{
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeMidHor) == true)
				{
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeUp) == true)
				{
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				
			}
			else if( Input.GetKeyDown ("space")/*Movement is down*/ )
			{
				if((threeDown && fiveHor) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
				}
				else if((threeDown && fourRight) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
				}
				else if((threeDown && fourLeft) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1+1, var2], 5f);
				}
				else if((threeDown && threeMidHor) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
				}
				else if((fiveHor) == true) 
				{
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((fourRight) == true)
				{
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((fourLeft)== true)
				{
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeMidHor) == true)
				{
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeDown) == true)
				{
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				
			}
			else if(Input.GetKeyDown ("shift") /*Movement is right*/ )
			{
				if((threeRight && fiveVert) == true)
				{
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1, var2], 5f);					
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);					
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
				}
				else if((threeRight && fourUp) == true)
				{
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeRight && fourDown) == true)
				{
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeRight && threeMidVert) == true)
				{
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((fiveVert) == true)
				{
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((fourUp) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
				}
				else if((fourDown) == true)
				{
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2]);
				}
				else if((threeMidVert) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2+1], 5f);
				}
				else if((threeRight) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1+1, var2], 5f);
					Destroy (cList[var1+2, var2], 5f);
				}
			}
			else if( Input.GetKeyDown ("tab")/*Movement is left*/ )
			{
				if((threeLeft && fiveVert) == true)
				{
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeLeft && fourUp) == true)
				{
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeLeft && fourDown) == true)
				{
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeLeft && threeMidVert) == true)
				{
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((fiveVert) == true)
				{
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((fourUp) == true)
				{
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2+2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((fourDown) == true)
				{
					Destroy (cList[var1, var2-2], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeMidVert) == true)
				{
					Destroy (cList[var1, var2+1], 5f);
					Destroy (cList[var1, var2-1], 5f);
					Destroy (cList[var1, var2], 5f);
				}
				else if((threeLeft) == true)
				{
					Destroy (cList[var1, var2], 5f);
					Destroy (cList[var1-1, var2], 5f);
					Destroy (cList[var1-2, var2], 5f);
				}
			}
		}
		/*else  non Valid move, return to original position
		{
			
		}*/
		
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
