using UnityEngine;
using System.Collections;

public class TurretEmitter : MonoBehaviour {
	public GameObject turretProjectile = null;
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		Instantiate(turretProjectile, position, transform.rotation);
	}
}
