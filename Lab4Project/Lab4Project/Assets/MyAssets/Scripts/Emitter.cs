using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {
	public GameObject projectile;
	private float nextFire = 0f;
	private float fireRate = 0f;
	private float speed = 10f;
	// Use this for initialization
	void Start () {
	
	}

		void Update () {
			if ( Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Vector3 position = transform.position;
				GameObject bullet = (GameObject)Instantiate(projectile, position, transform.rotation);
				bullet.rigidbody2D.velocity = transform.TransformDirection(Vector3.forward * 50);
			}
		}
}
