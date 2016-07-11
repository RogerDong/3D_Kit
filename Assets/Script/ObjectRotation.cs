using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ObjectRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//To show the object rotation information
		this.GetComponent<Text> ().text = GetInfo.rotation;
	}
}
