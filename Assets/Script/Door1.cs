using UnityEngine;
using System.Collections;

public class Door1 : MonoBehaviour {
	//To get the terrain and position
	public GameObject terrain;
	public float x;
	public float z;
	public int doorType ;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "FirstView") 
		{

			//If you touch the door, to press Q to create other zone
			//Different zone based on which door you enter
			if(Input.GetKeyDown(KeyCode.Q))
			{
				if(terrain.name == "Terrain" )
				{
					GetInfo.zone = 0;
					if( !GetInfo.zone0)
					{
						terrain.transform.position = new Vector3(x,0,z);
						Instantiate(terrain);
						GetInfo.zone0 = true;
					}
				}
				else if(terrain.name == "Terrain 1")
				{
					GetInfo.zone = 1;
					if( !GetInfo.zone1)
					{
						terrain.transform.position = new Vector3(x,0,z);
						Instantiate(terrain);
						GetInfo.zone1 = true;
					}
				}
				else if(terrain.name == "Terrain 2")
				{
					GetInfo.zone = 2;
					if( !GetInfo.zone2)
					{
						terrain.transform.position = new Vector3(x,0,z);
						Instantiate(terrain);
						GetInfo.zone2 = true;
					}
				}
				else if(terrain.name == "Terrain 3")
				{
					GetInfo.zone = 3;
					if( !GetInfo.zone3)
					{
						terrain.transform.position = new Vector3(x,0,z);
						Instantiate(terrain);
						GetInfo.zone3 = true;
					}
				}





				GameObject man = GameObject.Find("FirstView");
				//Change your position in the new zone.
				if(doorType == 1)
				{
					GameObject.Find("FirstView").transform.position = new Vector3( -(man.transform.position.x), man.transform.position.y, man.transform.position.z);

				}
				else if(doorType == 2)
				{
					GameObject.Find("FirstView").transform.position = new Vector3( man.transform.position.x, man.transform.position.y, -(man.transform.position.z));

				}
				else if(doorType == 0)
				{
					GameObject.Find("FirstView").transform.position = new Vector3( -man.transform.position.x, man.transform.position.y, -man.transform.position.z);
				}




			}
		}
	}
}
