using UnityEngine;
using System.Collections;

public class UserPosition : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

//		text.gameObject. =obj.transform.position.ToString ();

	}

	void OnGUI()
	{

		//A button to exit game
		if (GUI.Button (new Rect (Screen.width - 60, 0, 60, 20), "Exit")) 
		{
			Application.Quit();
		}

		//Show player information and object
		GUILayout.Label ("Zone: " + GetInfo.zone);
		GUILayout.Label ("View Position: " + this.transform.position);
		GUILayout.Label ("View Rotation: " + this.transform.eulerAngles);
		Ray getObjectInfo = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit objectInfo;
		if(Physics.Raycast(getObjectInfo,out objectInfo, 10, (1<<8) | (1<<9)))
		{
			GUILayout.Label("Object Position: " + objectInfo.transform.position);
			GUILayout.Label("Object Rotation: " + objectInfo.transform.eulerAngles);

		}


		//GUI.Toggle ();



	}
}
