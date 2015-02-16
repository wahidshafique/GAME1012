using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject emitter;
	private float speed = 1f;

	void Update () {
		this.transform.Translate(Vector2.right * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Enemy"){
			Destroy (gameObject);
		}
	}
}
