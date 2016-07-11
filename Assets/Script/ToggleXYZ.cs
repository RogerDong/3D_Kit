using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleXYZ : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//To make only one X,Y,Z toggle can be selected
		if (ToggleInfo.toggleXYZName != this.GetComponent<Toggle>().name) {
			this.GetComponent<Toggle>().isOn = false;
		}
	}
}
