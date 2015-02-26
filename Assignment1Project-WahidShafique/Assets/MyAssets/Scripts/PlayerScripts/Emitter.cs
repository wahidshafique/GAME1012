using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {
	public GameObject projectile;
	private float nextFire = 0f;
	private float fireRate = 0.5f; //intervals for projectile to emit

	void Update () {
		if ( Time.time > nextFire && Input.GetKeyDown(KeyCode.Space)){
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			Instantiate(projectile, position, transform.rotation);
		}
	}
}
