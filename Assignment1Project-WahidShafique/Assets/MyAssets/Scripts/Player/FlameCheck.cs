using UnityEngine;
using System.Collections;

public class FlameCheck : MonoBehaviour {
	//flame animation starts disabled, and is turned on by keypresses
	void Start(){
		this.renderer.enabled = false;
	}
	void Update () {
		if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right")){
			this.renderer.enabled = true;
		} else {
		this.renderer.enabled = false;
	}
}
}
