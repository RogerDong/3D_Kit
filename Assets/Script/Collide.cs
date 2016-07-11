using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

	private bool mouse = false;
	private Collider col ;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//If the 3D object's size is not to big, catch it in front of your camera
		if(mouse==true && col.transform.localScale.x <= 1 && col.transform.localScale.y <=1 && col.transform.localScale.z<=1 )
		{
			Vector3 v3 = Camera.main.transform.position + Camera.main.transform.forward * 2 ;
			col.transform.position = new Vector3((float)(int)(v3.x*10)/10,(float)(int)(v3.y*10)/10,(float)(int)(v3.z*10)/10);
			//col.transform.position = new Vector3(col.transform.position.x,col.transform.position.y,col
			if(col.transform.position.y<0.5)
			{
				col.transform.position = new Vector3 (col.transform.position.x, 0.5F, col.transform.position.z);
			}
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			mouse = false;
		}



	}

	void OnTriggerStay(Collider other)
	{
		//check whether touch an 3D object
		if(other.gameObject.name == "GridBlock(Clone)" || other.gameObject.name == "Cylinder(Clone)" || other.gameObject.name == "Sphere(Clone)" || other.gameObject.name == "Pyramid(Clone)")
		{
			//to get the object
			if (Input.GetMouseButtonDown (0)) {
				mouse = true;
				col = other;
			}
			//To destroy one object
			else if(Input.GetKeyDown(KeyCode.F))
			{
				Destroy(other.gameObject);
			}
		}




	}


}
