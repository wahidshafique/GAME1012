using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour {
	//controls player projectile, which exclusively moves RIGHT (unless shot from turret)
	private float speed = 15f;

	void Update () {
		this.transform.Translate(Vector2.right * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Bound" || coll.gameObject.tag == "Dead" ){
			Destroy (gameObject);
		}
	}
}
