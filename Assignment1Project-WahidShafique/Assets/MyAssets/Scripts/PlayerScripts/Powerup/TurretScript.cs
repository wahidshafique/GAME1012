using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	//controls turret rotation ala A and D keys
	private float rotationSpeed = 10;

	void Start () {print("turret is on");}//diagnostic

	void Update () {
		Rotate();
	}

	void Rotate () { //rotate the turret
		if (Input.GetKey(KeyCode.A))
			transform.Rotate(new Vector3(0, 0, -rotationSpeed));

		if (Input.GetKey(KeyCode.D))
			transform.Rotate(new Vector3(0, 0, rotationSpeed));
	}
}
