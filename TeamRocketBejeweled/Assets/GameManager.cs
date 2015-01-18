using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private const int SizeGrid = 7;
	private int Score = 0;
	private int[ , ] GridList = new int[ SizeGrid, SizeGrid ];
	private GameObject[ , ] cList = new GameObject[ SizeGrid, SizeGrid ];
	private int FinalTime = 180;
	private GameObject object1, object2;
	private Vector3 temp, position;
	private System.String name;
	private float intname;

	
	//creates first grid
	void Start () {
		
		//initialize Grid to a series of numbers between 1 and 4
		for ( int i = 0; i < SizeGrid; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				GridList[i, j] = Random.Range (1, 9);
			}
		}
	}

	//Call Random Generator to figure out which colored sphere to put where 
	//and place it there
	//also set up a name for each object in GridList via a number
	void ReShape() {
		int counter = 1;
		
		for ( int i = 0; i < SizeGrid; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				GameObject key = RandomGenerator( GridList[i, j], counter );
				cList[ i, j ] = key;
				GridList[ i, j ] = counter;
				counter++;
				key.renderer.material.color = new Vector3( i, j, 0 );

			}
		}
	}

	//create a function that will calculate which color each sphere will be
	GameObject RandomGenerator ( int a, int b ) {
		
		GameObject ans = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		//make them rigid body and box collider 

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
		ans.AddComponent<BoxCollider>();
		ans.AddComponent<Rigidbody>();

		return ans;
	}
	//finds all places where balls have been destroyed and everything has fallen and 
	//then replaces them with a new random ball

	void Dropping() {
		for ( int i = 3; i <= 6; i++ ) {
			for ( int j = 0; j < SizeGrid; j++ ) {
				if ( GameObject.Find( cList[i, j].name ) == null ) {
					int variable = Random.Range (1, 9);
					GameObject a = RandomGenerator( variable, GridList[ i, j ] );
					//Vector3( i, j, 0 ) = a;
					cList[ i, j ] = a;
				}
			}
		}
	}

	void Checks(int xcoor, int ycoor)
	{
		int var1;
		int var2;

		//WHERE DID UPDATES FUNCTION GO???!?
		//THERE ARE THREE ERRORS IN EACH OF THESE BOOLS -> 36 TOTAL ERRORS --- I THINK ONCE THESE ARE FOUND IT WILL WORK...
		bool threeLeft = ((GameObject.Find((GridList [var1, var2]).renderer.material.color == GameObject.Find (GridList [var1 - 1, var2]).renderer.material.color) && (GameObject.Find (GridList [var1, var2]).renderer.material.color == GameObject.Find(GridList [var1 - 2, var2]).renderer.material.color)));
		bool threeRight = ((GameObject.Find(Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1 + 1, var2,0)).renderer.material.color) && (GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1+2, var2,0)).renderer.material.color));
		bool threeUp = ((GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find((Vector3(var1, var2+1,0))).renderer.material.color) && (GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find(Vector3(var1, var2+2,0)).renderer.material.color));
		bool threeDown = ((GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find(Vector3(var1, var2-1,0)).renderer.material.color) && (GameObject.Find (Vector3(var1, var2,0)).renderer.material.color) == GameObject.Find (Vector3(var1, var2-2,0)).renderer.material.color);
		bool threeMidVert = (GameObject.Find(Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1, var2+1,0)).renderer.material.color) && (GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1, var2-1,0)).renderer.material.color);
		bool threeMidHor = ((GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1 + 1, var2,0)).renderer.material.color) && (GameObject.Find (Vector3(var1, var2,0)).renderer.material.color) == GameObject.Find (Vector3(var1-1, var2,0)).renderer.material.color);
		
		bool fourUp = ((GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1, var2+1,0)).renderer.material.color) && (GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1, var2+2,0)).renderer.material.color && GameObject.Find(Vector3(var1, var2,0)).renderer.material.color  == GameObject.Find (Vector3(var1, var2-1,0)).renderer.material.color));
		bool fourDown = ((GameObject.Find (Vector3 (var1, var2, 0)).renderer.material.color == GameObject.Find (Vector3 (var1, var2 - 1, 0)).renderer.material.color) && (GameObject.Find (Vector3 (var1, var2, 0)).renderer.material.color == GameObject.Find (Vector3 (var1, var2 - 2, 0)).renderer.material.color && GameObject.Find (Vector3 (var1, var2, 0)).renderer.material.color == GameObject.Find (Vector3 (var1, var2 + 1, 0)).renderer.material.color));
		bool fourRight = ((GameObject.Find(Vector3(var1, var2,0)).renderer.material.color == GameObject.Find(Vector3(var1+1, var2,0)).renderer.material.color) && (GameObject.Find(Vector3(var1, var2,0)).renderer.material.color== GameObject.Find (Vector3(var1+2, var2,0)).renderer.material.color) && GameObject.Find(Vector3(var1, var2,0)).renderer.material.color == GameObject.Find(Vector3(var1-1, var2,0)).renderer.material.color);
		bool fourLeft = (((GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1-1, var2,0)).renderer.material.color) && GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1-2, var2,0)).renderer.material.color) && GameObject.Find (Vector3(var1, var2,0)).renderer.material.color  == GameObject.Find (Vector3(var1+1, var2,0)).renderer.material.color);
		
		bool fiveVert = ((GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1, var2+1,0)).renderer.material.color) && GameObject.Find (Vector3(var1, var2,0)).renderer.material.color  == GameObject.Find (Vector3(var1, var2+2,0)).renderer.material.color) && GameObject.Find(Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1, var2-1,0)).renderer.material.color && GameObject.Find(Vector3(var1, var2,0)).renderer.material.color  == GameObject.Find (Vector3(var1, var2-2,0)).renderer.material.color;
		bool fiveHor = ((GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1+1, var2,0)).renderer.material.color) && GameObject.Find (Vector3(var1, var2,0)).renderer.material.color == GameObject.Find (Vector3(var1+2, var2,0)).renderer.material.color) && GameObject.Find (Vector3(var1, var2,0)).renderer.material.color  == GameObject.Find (Vector3(var1-1, var2,0)).renderer.material.color && GameObject.Find (Vector3(var1, var2,0)).renderer.material.color  == GameObject.Find (Vector3(var1-2, var2,0)).renderer.material.color;
		
		if(Input.GetKeyDown (KeyCode.W))
		{
			var1 = xcoor;
			var2 = ycoor+1;
			if((threeLeft || threeRight || threeUp || threeMidVert) == true)   
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
			else
			{
				ReShape();
			}
			Dropping();
			ReShape();
		}
		else if( Input.GetKeyDown (KeyCode.S))
		{
			var1=xcoor;
			var2=ycoor-1;
			if((threeLeft || threeRight || threeDown || threeMidHor ) == true)   
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
			else
			{
				ReShape();
			}
			Dropping();
			ReShape();
		}
		else if(Input.GetKeyDown (KeyCode.D))
		{
			var1=xcoor+1;
			var2=ycoor;
			if((threeRight || threeUp || threeDown || threeMidVert) == true)   
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
			else
			{
				ReShape();
			}
			Dropping();
			ReShape();
		}
		else if( Input.GetKeyDown (KeyCode.A)/*Movement is left*/ )
		{
			var1=xcoor-1;
			var2=ycoor;
			if((threeLeft || threeUp || threeDown || threeMidVert) == true)   
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
			else
			{
				ReShape();
			}
			Dropping();
			ReShape();
		}
		
	}

	void Swap()
	{
		
		//Get mouse input of the sphere to swap.
		if (Input.GetMouseButtonDown(0))
		{
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit,1000))
			{
				position = hit.collider.renderer.material.color;
				position[1]++;
				name = hit.collider.transform.name;
			}
		}
		//print (position [0]);
		//print (position [1]);
		object1 = GameObject.Find (name);
		intname = int.Parse (name);
		//Test key input
		if (Input.GetKeyDown (KeyCode.W) && position[1] < SizeGrid) 
		{
			position [1]++;
			intname++;
			float a = position [0];
			//print (position[0]);
			float b = position [1];
			//print (position[1]);
			intname = (a * 7) + b;
			name = intname.ToString ();
			
			//Run swapping algorithm.
			object2 = GameObject.Find (name);
			temp = object1.renderer.material.color;
			object1.renderer.material.color = object2.renderer.material.color;
			object2.renderer.material.color = temp;
			
			//Change the names to make the grid stay the same.
			string somename = object2.name;
			string anothername = object1.name;
			object2.name = anothername;
			print (anothername);
			object1.name = somename;
			print (somename);
			
			return;
		}
		else if (Input.GetKeyDown (KeyCode.A) && position[0] > 0)
		{
			position [0]--;
			intname-=SizeGrid;
			float a = position [0];
			//print (position[0]);
			float b = position [1];
			//print (position[1]);
			intname = (a * 7) + b;
			name = intname.ToString ();
			
			//Run swapping algorithm.
			object2 = GameObject.Find (name);
			temp = object1.renderer.material.color;
			object1.renderer.material.color = object2.renderer.material.color;
			object2.renderer.material.color = temp;
			
			//Change the names to make the grid stay the same.
			string somename = object2.name;
			string anothername = object1.name;
			object2.name = anothername;
			print (anothername);
			object1.name = somename;
			print (somename);
			
			return;
		}
		else if (Input.GetKeyDown (KeyCode.S) && position[1] > 1)
		{
			position [1]--;
			intname--;
			float a = position [0];
			//print (position[0]);
			float b = position [1];
			//print (position[1]);
			intname = (a * 7) + b;
			name = intname.ToString ();
			
			//Run swapping algorithm.
			object2 = GameObject.Find (name);
			temp = object1.renderer.material.color;
			object1.renderer.material.color = object2.renderer.material.color;
			object2.renderer.material.color = temp;
			
			//Change the names to make the grid stay the same.
			string somename = object2.name;
			string anothername = object1.name;
			object2.name = anothername;
			print (anothername);
			object1.name = somename;
			print (somename);
			
			return;
		}
		else if (Input.GetKeyDown (KeyCode.D) && position[0] < SizeGrid - 1)
		{
			position [0]++;
			intname+=SizeGrid;
			float a = position [0];
			//print (position[0]);
			float b = position [1];
			//print (position[1]);
			intname = (a * 7) + b;
			name = intname.ToString ();
			
			//Run swapping algorithm.
			object2 = GameObject.Find (name);
			temp = object1.renderer.material.color;
			object1.renderer.material.color = object2.renderer.material.color;
			object2.renderer.material.color = temp;
			
			//Change the names to make the grid stay the same.
			string somename = object2.name;
			string anothername = object1.name;
			object2.name = anothername;
			print (anothername);
			object1.name = somename;
			print (somename);
			
			return;
		}

	}
} 
