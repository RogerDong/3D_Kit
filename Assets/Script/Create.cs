using UnityEngine;
using System.Collections;
using System;

public class Create : MonoBehaviour {
	private int createType;
	public GameObject cube;
	public GameObject pyramid;
	public GameObject sphere;
	public GameObject cylinder;
	public GameObject rectangle;
	public GameObject line;
	public GameObject circle;
	public GameObject trapeze;
	public GameObject door;

	// Use this for initialization
	void Start () {
		createType = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//To choose the object type you want to create
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			createType = 1;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			createType = 2;		
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			createType = 3;
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			createType = 4;
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			createType = 5;		
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			createType = 6;
		} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			createType = 7;
		} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			createType = 8;
		} else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			createType = 0;
		}

		//When you create an object, giving an integer position. 
		Vector3 v3 = Camera.main.transform.position + Camera.main.transform.forward * 2;
		v3 = new Vector3 ((int)v3.x,(float)((int)(v3.y)+0.5),(int)v3.z);


		//To create the object that you chose.
		if (Input.GetMouseButtonDown (1)) 
		{
			if(createType == 1)
			{
				cube.transform.position = v3;
				Instantiate(cube);
			}
			else if(createType == 2)
			{
				pyramid.transform.position = v3;
				Instantiate(pyramid);
			}
			else if(createType == 3)
			{
				sphere.transform.position = v3;
				Instantiate(sphere);
			}
			else if(createType == 4)
			{
				cylinder.transform.position = v3;
				Instantiate(cylinder);
			}
			else if(createType == 5)
			{
				rectangle.transform.position = v3;

				Instantiate(rectangle);
			}
			else if(createType == 6)
			{
				line.transform.position = v3;
				Instantiate(line);
			}
			else if(createType == 7)
			{
				circle.transform.position = v3;
				Instantiate(circle);
			}
			else if(createType == 8)
			{
				trapeze.transform.position = v3;
				Instantiate(trapeze);
			}
			else if (createType == 0)
			{
				door.transform.position = v3;
				Instantiate(door); 

			}


		}

	}
}
