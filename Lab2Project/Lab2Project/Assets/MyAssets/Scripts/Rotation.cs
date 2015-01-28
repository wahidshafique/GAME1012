using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	public Vector3 rotationAxis = new Vector3 (0,1,0);
	// Use this for initialization

	public void Rotate(float speed){
		this.transform.Rotate(this.rotationAxis,speed);
		}
}
