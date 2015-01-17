
public class BeJeweled : MonoBehaviour {

	public int[] gridList;
	public int[] cList;
	public int[] cList2;

	// Use this for initialization
	void Start () 
	{
		gridList = new int[49];

		for (int i=0; i<49; i++) 
		{
			int rand = Random.Range (1, 5);
			gridList[i] = rand;
		}

		for (int i=0; i<49; i++) 
		{
			print (gridList[i]);		
		}

		//cList = new int[7, 7];
		//cList2 = new int[7, 7];

//		for (int i=0; i<49; i++) 
//		{
//			for(int j=0; j<7; j++)
//			{
//				for(int k=0; k<7; k++)
//				{
//					cList[j,k] = gridList[i];
//					cList2[j,k] = gridList[i];
//				}
//			}
//		}

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


	
	
	}

	/*boolean possib1 = (cList[q+1,w]==(cList[q+2,w] && cList[q+3,w]));
	boolean possib2 = (cList[q+1,w]==(cList[q+1,w+1] && cList[q+1,w+2]));
	boolean possib3 = (cList[q+1,w]==(cList[q+1,w-1] && cList[q+1,w-2]));

	boolean possib4 = (cList[q-1,w]==(cList[q-2,w] && cList[q-3,w]));
	boolean possib5 = (cList[q-1,w]==(cList[q-1,w+1] && cList[q-1,w+2]));
	boolean possib6 = (cList[q-1,w]==(cList[q-1,w-1] && cList[q-1,w-2]));

	boolean possib7 = (cList[q,w+1]==(cList[q,w+2] && cList[q,w+3]));
	boolean possib8 = (cList[q,w+1]==(cList[q+1,w+1] && cList[q+2,w+1]));
	boolean possib9 = (cList[q,w+1]==(cList[q-1,w+1] && cList[q-2,w+1]));
	
	boolean possib10 = (cList[q,w-1]==(cList[q,w-2] && cList[q,w-3]));	
	boolean possib11 = (cList[q,w-1]==(cList[q+1,w-1] && cList[q+2,w-1]));
	boolean possib12 = (cList[q,w-1]==(cList[q-1,w-1] && cList[q-2,w-1]));


	
	// Update is called once per frame
	void Update () 
	{
		//Used after movement. variables q and w are grid locations of the chosen shape.
		if(possib1 || possib2 || possib3) //Moved right
		{
			if(possib1)
			{
				if(cList[q+1,w]==(cList[q+4,w] && cList[q+5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+4,w])
				{

				}
			}

			else if(possib2)
			{
				if(cList[q+1,w]==(cList[q+1,w+3] && cList[q+1,w+4]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+1,w+3])
				{
					
				}
			}

			else if(possib3)
			{
				if(cList[q+1,w]==(cList[q+1,w-3] && cList[q+1,w-4]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+1,w-3])
				{
					
				}
			}

		}
		else if(possib4 || possib5 || possib6)//Moved left
		{

			if(possib4)
			{
				if(cList[q-1,w]==(cList[q-4,w] && cList[q-5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q-1,w] == cList[q-4,w])
				{
					
				}
			}

			else if(possib5)
			{
				if(cList[q-1,w]==(cList[q-1,w+3] && cList[q-1,w+4]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q-1,w] == cList[q-1,w])
				{
					
				}
			}

			else if(possib6)
			{
				if(cList[q+1,w]==(cList[q+4,w] && cList[q+5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+4,w])
				{
					
				}
			}

		}
		else if(possib7 || possib8 || possib9)//Moved up
		{
			
			if(possib7)
			{
				if(cList[q+1,w]==(cList[q+4,w] && cList[q+5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+4,w])
				{
					
				}
			}
			
			else if(possib8)
			{
				if(cList[q+1,w]==(cList[q+4,w] && cList[q+5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+4,w])
				{
					
				}
			}
			
			else if(possib9)
			{
				if(cList[q+1,w]==(cList[q+4,w] && cList[q+5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+4,w])
				{
					
				}
			}

		}
		else if(possib10 || possib11 || possib12)//Moved down
		{
			
			if(possib10)
			{
				if(cList[q+1,w]==(cList[q+4,w] && cList[q+5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+4,w])
				{
					
				}
			}
			
			else if(possib11)
			{
				if(cList[q+1,w]==(cList[q+4,w] && cList[q+5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+4,w])
				{
					
				}
			}
			
			else if(possib12)
			{
				if(cList[q+1,w]==(cList[q+4,w] && cList[q+5,w]))
				{
					//Destroy objects and replace rearrange array
				}
				else if(cList[q+1,w] == cList[q+4,w])
				{
					
				}
			}

		}
		//No matches of at least 3
		else if(!(possib1 || possib2 || possib3 || possib4 || possib5 || possib6 || possib7 || possib8 || possib9 || possib10 || possib11 || possib12))
		{

		}

	}
	*/
}
