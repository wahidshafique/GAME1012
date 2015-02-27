using UnityEngine;
using System.Collections;

public class FlameCheck : MonoBehaviour {
	//flame animation starts disabled, and is turned on by keypresses
	void Start() {
		this.renderer.enabled = false;//flame is always present, just not visible until player moves
	}

	void Update () {
		//any arrow key movement enables the flame
		if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
			this.renderer.enabled = true;
		else 
		this.renderer.enabled = false;
	}
}
