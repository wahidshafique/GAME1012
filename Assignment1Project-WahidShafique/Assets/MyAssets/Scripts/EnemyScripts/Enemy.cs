using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float speed = 8f;
	Animator anim;
	void Start (){
		anim = GetComponent <Animator>();
	}

	void Update () {
		this.transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Bullet"){
			anim.SetBool ("Dead", true);
			this.rigidbody2D.gravityScale = 3; //sets gravity scale to high to simulate fall
		}
		if (coll.gameObject.tag == "Bound"){
			Destroy (gameObject);
		}
	}
}

