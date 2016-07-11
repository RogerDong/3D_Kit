using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//To show the color information
		this.GetComponent<Text> ().text = GetInfo.color;
	}
}
