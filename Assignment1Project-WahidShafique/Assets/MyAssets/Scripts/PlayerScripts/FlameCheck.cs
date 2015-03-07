using UnityEngine;
using System.Collections;

public class FlameCheck : MonoBehaviour {
	//flame animation starts disabled, and is turned on by keypresses
	void Start() {
		this.GetComponent<Renderer>().enabled = false;//flame is always present, just not visible until player moves
	}

	void Update () {
		//any arrow key movement enables the flame
		if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
			this.GetComponent<Renderer>().enabled = true;
		else 
		this.GetComponent<Renderer>().enabled = false;
	}
}
