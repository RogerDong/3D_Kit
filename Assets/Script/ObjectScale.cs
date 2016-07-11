using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ObjectScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//to show object scale information
		this.GetComponent<Text> ().text = GetInfo.scale;
	}
}
