using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ObjectPosition : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//To show the position information
		this.GetComponent<Text> ().text = GetInfo.position;

	}

}
