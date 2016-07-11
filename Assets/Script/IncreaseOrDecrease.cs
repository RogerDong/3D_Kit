using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class IncreaseOrDecrease : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//To increase or decrease one attribute of selected object
	// the type is to control that is increse or decrease.
	public void IncreaseDecrease( int type){
		float move = 0;
		//Get the inputvalue of player.
		try
		{
			 move = float.Parse( GameObject.FindGameObjectWithTag("Input").GetComponent<InputField>().text);
		}
		catch
		{
			move = 0f;
		}
	
		//To limit the position that user can change.
		float xFrom = 0;
		float xTo = 0;
		float zFrom = 0;
		float zTo = 0;
		if (GetInfo.zone == 0) {
			xTo = 500;
			xFrom = 0;
			zTo = 500;
			zFrom = 0;
		} else if (GetInfo.zone == 1) {
			xTo = 0;
			xFrom = -500;
			zTo = 0;
			zFrom = -500;
		} else if (GetInfo.zone == 2) {
			xTo = 500;
			xFrom = 0;
			zTo = 0;
			zFrom = -500;
		} else if (GetInfo.zone == 3) {
			xTo = 0;
			xFrom = -500;
			zTo = 500;
			zFrom = 0;
		}
		if (type == 2) {
			move = -move;
		}
		try
		{

			//To check and change the value of one attribute.

			//change position
			if (ToggleInfo.togglePRSName == "Toggle P") {
				
				if(ToggleInfo.toggleXYZName == "Toggle X" && GetInfo.obj.transform.position.x+move > xFrom && GetInfo.obj.transform.position.x+move < xTo )
				{
					GetInfo.obj.transform.position = new Vector3(GetInfo.obj.transform.position.x+move,GetInfo.obj.transform.position.y,GetInfo.obj.transform.position.z);
				}
				else if(ToggleInfo.toggleXYZName == "Toggle Y" && GetInfo.obj.transform.position.y+move > 0 && GetInfo.obj.transform.position.y+move < 180)
				{
					GetInfo.obj.transform.position = new Vector3(GetInfo.obj.transform.position.x,GetInfo.obj.transform.position.y+move,GetInfo.obj.transform.position.z);
				}
				else if(ToggleInfo.toggleXYZName == "Toggle Z" && GetInfo.obj.transform.position.z+move > zFrom && GetInfo.obj.transform.position.z+move < zTo)
				{
					GetInfo.obj.transform.position = new Vector3(GetInfo.obj.transform.position.x,GetInfo.obj.transform.position.y,GetInfo.obj.transform.position.z+move);
				}
			} 
			//change rotation
			else if (ToggleInfo.togglePRSName == "Toggle R") {
				
				if(ToggleInfo.toggleXYZName == "Toggle X" )
				{
					GetInfo.obj.transform.eulerAngles = new Vector3( GetInfo.obj.transform.eulerAngles.x+move, GetInfo.obj.transform.eulerAngles.y, GetInfo.obj.transform.eulerAngles.z);
				}
				else if(ToggleInfo.toggleXYZName == "Toggle Y")
				{
					GetInfo.obj.transform.eulerAngles = new Vector3( GetInfo.obj.transform.eulerAngles.x, GetInfo.obj.transform.eulerAngles.y + move, GetInfo.obj.transform.eulerAngles.z);
				}
				else if(ToggleInfo.toggleXYZName == "Toggle Z")
				{
					GetInfo.obj.transform.eulerAngles = new Vector3( GetInfo.obj.transform.eulerAngles.x, GetInfo.obj.transform.eulerAngles.y, GetInfo.obj.transform.eulerAngles.z+move);
				}
			} 
			//change scale
			else if (ToggleInfo.togglePRSName == "Toggle S") {
				if(ToggleInfo.toggleXYZName == "Toggle X")
				{
					GetInfo.obj.transform.localScale = new Vector3(GetInfo.obj.transform.localScale.x+move,GetInfo.obj.transform.localScale.y,GetInfo.obj.transform.localScale.z);
				}
				else if(ToggleInfo.toggleXYZName == "Toggle Y")
				{
					GetInfo.obj.transform.localScale = new Vector3(GetInfo.obj.transform.localScale.x,GetInfo.obj.transform.localScale.y+move,GetInfo.obj.transform.localScale.z);
				}
				else if(ToggleInfo.toggleXYZName == "Toggle Z")
				{
					GetInfo.obj.transform.localScale = new Vector3(GetInfo.obj.transform.localScale.x,GetInfo.obj.transform.localScale.y,GetInfo.obj.transform.localScale.z+move);
				}
			}
			//change color
			else if( ToggleInfo.togglePRSName == "Toggle C")
			{
				Color32 c32 = GetInfo.obj.GetComponent<MeshRenderer>().material.color;
				Color c = new Color();

	
				if(ToggleInfo.toggleXYZName == "Toggle X")
				{
					c = new Color32(Convert.ToByte( c32.r+move),c32.g,c32.b,c32.a);

				}
				else if(ToggleInfo.toggleXYZName == "Toggle Y")
				{
					c = new Color32(c32.r,Convert.ToByte( c32.g + move ),c32.b,c32.a);
				}
				else if(ToggleInfo.toggleXYZName == "Toggle Z")
				{
					c = new Color32(c32.r, c32.g, Convert.ToByte(c32.b+move),c32.a);

				}
				GetInfo.obj.GetComponent<MeshRenderer>().material.color = c;
			
			}
		}
		catch
		{
			return;
		}


		
	}




}
