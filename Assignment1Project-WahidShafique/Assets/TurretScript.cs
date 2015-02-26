using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	private float rotationSpeed = 10;
	//public GameObject turretProjectile = null;
	//public Transform turretEmitter= null;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rotate();
	}
	void Rotate ()
	{ //rotate the turret
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(new Vector3(0, 0, -rotationSpeed));
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(new Vector3(0, 0, rotationSpeed));
		}
	}
}
