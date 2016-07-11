using UnityEngine;
using System.Collections;

public class DistroyCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//If press V, to destroy the infobox canvas
		if (Input.GetKeyDown (KeyCode.V)) {
			DestroyObject(this.gameObject);
			GetInfo.controlCanvas = false;
		}
	}

}
