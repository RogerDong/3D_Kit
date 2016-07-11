using UnityEngine;
using System.Collections;

public class StartOrExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}

	//To start or exit the game
	public void start()
	{
		Application.LoadLevel (1);
	}
	public void exit()
	{

		Application.Quit ();
	}
}
