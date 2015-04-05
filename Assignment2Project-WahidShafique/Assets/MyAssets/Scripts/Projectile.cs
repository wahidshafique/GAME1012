using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour { 
	//the projectile ejected from Turret Emitter
	private float speed = 10f;
	
	void Update () {
		this.transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D coll){
		tag = coll.gameObject.tag;
		if (tag == "Player"){
			Destroy (this.gameObject);
		}
	}
}