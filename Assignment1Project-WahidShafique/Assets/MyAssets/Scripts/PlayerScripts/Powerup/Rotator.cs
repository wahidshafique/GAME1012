using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	//used when the bomb powerup is active, this just makes the active powerup spin around player
	void Start(){print("bombs away");}//diagnostic

	void Update () {
		this.transform.Rotate(new Vector3(0, 0, 16));
	}
}
