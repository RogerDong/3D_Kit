using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	public GameObject obj;
	public float xChange;
	public float yChange;
	public string position;
	// Use this for initialization
	void Start () {

		//To put one UI at the position of your screen.
		float x = 0;
		float y = 0;
		if(position == "topleft")
		{
			x = -Screen.width / 2 + xChange;
			y = Screen.height / 2 - yChange;
			this.GetComponent<RectTransform> ().Translate(x,y,0);
		}
		else if (position == "topright")
		{
			x = Screen.width / 2 - xChange;
			y = Screen.height / 2 - yChange;
			this.GetComponent<RectTransform> ().Translate(x,y,0);
		}



	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
