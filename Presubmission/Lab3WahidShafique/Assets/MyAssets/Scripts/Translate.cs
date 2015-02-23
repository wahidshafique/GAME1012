using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {
	public float speed=0;
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (speed, 0, 0);
	}
}
