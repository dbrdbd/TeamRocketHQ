	private GameObject object1, object2, testob1,testob2,testob3,testob4,testob5,testob6,testob7,testob8;
	private Vector3 temp, position;
	private System.String name;
	private float intname;
	void Update()
	{
		int gridsize = 7;

		//Get mouse input of the sphere to swap.
		if (Input.GetMouseButtonDown(0))
		{
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit,1000))
			{
				position = hit.collider.transform.position;
				position[1]++;
				name = hit.collider.transform.name;
			}
		}
		//print (position [0]);
		//print (position [1]);
		object1 = GameObject.Find (name);
		intname = int.Parse (name);
		//Test key input
		if (Input.GetKeyDown (KeyCode.W) && position[1] < gridsize) 
		{
			position [1]++;
			intname++;
			float a = position [0];
			//print (position[0]);
			float b = position [1];
			//print (position[1]);
			intname = (a * 7) + b;
			name = intname.ToString ();

			object2 = GameObject.Find (name);

			//Run swapping algorithm.
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
			
			//Change the names to make the grid stay the same.
			string somename = object2.name;
			string anothername = object1.name;
			object2.name = anothername;
			print (anothername);
			object1.name = somename;
			print (somename);

		}
		else if (Input.GetKeyDown (KeyCode.A) && position[0] > 0)
		{
			position [0]--;
			intname-=gridsize;
			float a = position [0];
			//print (position[0]);
			float b = position [1];
			//print (position[1]);
			intname = (a * 7) + b;
			name = intname.ToString ();
			
			//Run swapping algorithm.
			object2 = GameObject.Find (name);
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
			
			//Change the names to make the grid stay the same.
			string somename = object2.name;
			string anothername = object1.name;
			object2.name = anothername;
			print (anothername);
			object1.name = somename;
			print (somename);
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
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
			
			//Change the names to make the grid stay the same.
			string somename = object2.name;
			string anothername = object1.name;
			object2.name = anothername;
			print (anothername);
			object1.name = somename;
			print (somename);
		}
		else if (Input.GetKeyDown (KeyCode.D) && position[0] < gridsize - 1)
		{
			position [0]++;
			intname+=gridsize;
			float a = position [0];
			//print (position[0]);
			float b = position [1];
			//print (position[1]);
			intname = (a * 7) + b;
			name = intname.ToString ();
			
			//Run swapping algorithm.
			object2 = GameObject.Find (name);
			temp = object1.transform.position;
			object1.transform.position = object2.transform.position;
			object2.transform.position = temp;
			
			//Change the names to make the grid stay the same.
			string somename = object2.name;
			string anothername = object1.name;
			object2.name = anothername;
			print (anothername);
			object1.name = somename;
			print (somename);
		}
	}
}
