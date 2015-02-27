using UnityEngine;
using System.Collections;

public class TurretProjectile : MonoBehaviour {
	//the projectile ejected from TurretEmitter
	private float speed = 15f;

	void Update () {
		this.transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Bound"){
			Destroy (gameObject);
		}
	}
}
