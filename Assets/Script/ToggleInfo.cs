using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleInfo : MonoBehaviour {


	//To store the toggle that user selected
	public static string togglePRSName;
	public static string toggleXYZName;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	//To change the variable to be the selected one 
	public void SelectPRS( Toggle toggle)
	{
		if (toggle.isOn == true) {
			if (toggle.name == "Toggle P") {

				togglePRSName = "Toggle P";
			}
			else if (toggle.name == "Toggle R")
			{

				togglePRSName = "Toggle R";
			}
			else if(toggle.name == "Toggle S")
			{

				togglePRSName = "Toggle S";
			}
			else if(toggle.name == "Toggle C")
			{
				togglePRSName = "Toggle C";
			}


		}
		if (togglePRSName == toggle.name) {
			if(toggle.isOn == false)
			{
				togglePRSName = null;
			}
		}


	}
	public void SelectXYZ( Toggle toggle )
	{
		if (toggle.isOn == true) {
			if (toggle.name == "Toggle X") {
				
				toggleXYZName = "Toggle X";
			}
			else if (toggle.name == "Toggle Y")
			{
				
				toggleXYZName = "Toggle Y";
			}
			else if(toggle.name == "Toggle Z")
			{
				
				toggleXYZName = "Toggle Z";
			}
			
			
		}

		//If no toggle is selected, change the variable to null 
		if (toggleXYZName == toggle.name) {
			if(toggle.isOn == false)
			{
				toggleXYZName = null;
			}
		}
	}
}
