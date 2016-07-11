using UnityEngine;
using System.Collections;

public class Door2 : MonoBehaviour {

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


			//To choose an exsiting zone randomly, but not the zone you already in..
			if(Input.GetKeyDown(KeyCode.Q))
			{

				System.Random rnd = new System.Random();
				int num = 0;

				while(true)
				{
					num = rnd.Next(0,4);
					if( !( GetInfo.zone1 || GetInfo.zone2 || GetInfo.zone3))
					{
						break;
					}
					if(GetInfo.zone == num)
					{
						continue;
					}
					//To check whether the zone is exsiting or not.
					if( num == 0 && GetInfo.zone0 )
					{
						GameObject.Find("FirstView").transform.position = new Vector3( 250,15,250 );
						GetInfo.zone = 0;
						break;
					}
					else if( num == 1 && GetInfo.zone1 )
					{
						GameObject.Find("FirstView").transform.position = new Vector3( -250,15,-250 );
						GetInfo.zone = 1;
						break;
					}
					else if( num == 2 && GetInfo.zone2)
					{
						GameObject.Find("FirstView").transform.position = new Vector3( 250,15,-250 );
						GetInfo.zone = 2;
						break;
					}
					else if( num == 3 && GetInfo.zone3)
					{
						GameObject.Find("FirstView").transform.position = new Vector3( -250,15,250 );
						GetInfo.zone = 3;
						break;
					}
				}
			}
		}
	}
}
