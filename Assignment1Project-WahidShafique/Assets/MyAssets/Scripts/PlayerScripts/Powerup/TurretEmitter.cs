using UnityEngine;
using System.Collections;

public class TurretEmitter : MonoBehaviour {
	//controls burst of projectiles the eject from the tip of the turret barrel 
	public GameObject turretProjectile = null;
	private float nextFire = 0f;//controls first instance of instantiated object
	private float fireRate = 0.1f; //intervals for projectile to emit

	void Update () {
		if ( Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			Instantiate(turretProjectile, position, transform.rotation);
		}
	}
}
