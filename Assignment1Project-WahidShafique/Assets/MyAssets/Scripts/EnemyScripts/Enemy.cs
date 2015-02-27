using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour { 
	//controls behaviour of enemies 
	public GameObject explosionPrefab = null;
	private float speed = 8f;
	private int score = 0;
	Animator anim;

	void Start (){
		anim = GetComponent <Animator>();
	}

	void Update () {
		this.transform.Translate(Vector3.left * speed * Time.deltaTime); //sets the trajectory for the enemies
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Bullet"){
			anim.SetBool ("Dead", true);
			this.gameObject.tag = "Dead";
			GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
			explosionObject.transform.position = this.transform.position; //creates explosion
			this.rigidbody2D.gravityScale = 3; //sets gravity scale to high to simulate fall
		}
		if (coll.gameObject.tag == "Bound") Destroy (gameObject);
	}
}
