using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float speed;
	
	private void Update() {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
	
	private void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer("Stop")) {
			Destroy(gameObject);
		}
	}
	
}