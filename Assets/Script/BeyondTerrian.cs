using UnityEngine;
using System.Collections;

public class BeyondTerrian : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//to make all objects beyond the ground. And not fall into the ground.
		if (this.gameObject.name == "GridBlock(Clone)" || this.gameObject.name == "Sphere(Clone)" || this.gameObject.name == "Pyramid(Clone)") {

			if (this.gameObject.transform.position.y * 2 < this.gameObject.transform.localScale.y) {
				this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.localScale.y / 2, this.gameObject.transform.position.z);
			}
		} else if (this.gameObject.name == "Cylinder(Clone)") 
		{
			if (this.gameObject.transform.position.y  < this.gameObject.transform.localScale.y) {
				this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.localScale.y , this.gameObject.transform.position.z);
			}
		}
	}
}
