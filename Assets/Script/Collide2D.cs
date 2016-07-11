using UnityEngine;
using System.Collections;

public class Collide2D : MonoBehaviour {


	private bool mouseDown = false;
	private Collider col ;

	// Use this for initialization
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//if the 2D object's size is not too big, you can catch it in front of your camera
		if(mouseDown && col.transform.localScale.x <= 1 && col.transform.localScale.y <=1.5 && col.transform.localScale.z<=1)
		{
			col.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2 ;
			if(col.transform.position.y<0 )
			{
				col.transform.position = new Vector3 (col.transform.position.x, 0, col.transform.position.z);
			}
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			mouseDown = false;
		}
		

		
	}

	void OnTriggerStay(Collider other)
	{
		//To get the 2D object or press F to destroy
		if(other.gameObject.name == "Line(Clone)" || other.gameObject.name == "Circle(Clone)" || other.gameObject.name == "Rectangle(Clone)" || other.gameObject.name == "Rectangle(Clone)" || other.gameObject.name == "Trapeze(Clone)" || other.gameObject.name == "Door2(Clone)")
		{
			
			if (Input.GetMouseButtonDown (0)) {
				mouseDown = true;
				col = other;

			}
			else if(Input.GetKeyDown(KeyCode.F))
			{
				Destroy(other.gameObject);

			}

		}
		
		

		
	}
}
