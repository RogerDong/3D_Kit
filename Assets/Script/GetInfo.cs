using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetInfo : MonoBehaviour {

	//To offer the position, rotation, scale, color information to other class.
	public static string position;
	public static string rotation;
	public static string scale;
	public static string color;

	//To offer the zone information to others.
	public static int zone;
	public static bool controlCanvas;
	public static bool zone0;
	public static bool zone1;
	public static bool zone2;
	public static bool zone3;

	//To get the canvas.
	public GameObject canvas;



	//To offer the selected object
	public static Collider obj;


	// Use this for initialization
	void Start () {
		zone = 0;
		controlCanvas = false;
		zone0 = true;
		zone1 = false;
		zone2 = false;
		zone3 = false;
	
	}
	 
	// Update is called once per frame
	void Update () {

		//To get the selected object information
		if(  obj!=null && (obj.gameObject.name == "GridBlock(Clone)" || obj.gameObject.name == "Cylinder(Clone)" || obj.gameObject.name == "Sphere(Clone)" || obj.gameObject.name == "Pyramid(Clone)"||
		   obj.gameObject.name == "Line(Clone)" || obj.gameObject.name == "Rectangle(Clone)" || obj.gameObject.name == "Rectangle(Clone)" || obj.gameObject.name == "Trapeze(Clone)"))
		{
			position = obj.gameObject.transform.position.ToString();
			rotation = obj.gameObject.transform.eulerAngles.ToString();
			scale = obj.gameObject.transform.localScale.ToString();
			Color32 color32 = obj.gameObject.GetComponent<MeshRenderer>().material.color;
			color = color32.ToString();


		}






	}



	void OnTriggerStay(Collider other)
	{
		//To select one object and show infobox
		if(Input.GetKeyDown(KeyCode.C) && other.gameObject.tag == "Object" && controlCanvas == false)
		{

			obj = other;
			Instantiate (canvas);	
			controlCanvas = true;
			
		}
	}
}
