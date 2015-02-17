using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {
	public GameObject projectile;
	private float nextFire = 0f;
	private float fireRate = 1f; //intervals for projectile to emit

	void Update () {
		if ( Time.time > nextFire && Input.GetKey(KeyCode.Space)){
			nextFire = Time.time + fireRate;
			Vector3 position = transform.position;
			GameObject bullet = (GameObject)Instantiate(projectile, position, transform.rotation);
		}
	}
}
