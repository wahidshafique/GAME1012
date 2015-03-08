using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour { 
	//controls behaviour of enemies 
	public GameObject explosionPrefab = null;
	public bool isSpecial = false; 
	private float speed = 8f;
	Animator anim;
	Rigidbody2D rigid;

	void Awake (){
		anim = GetComponent <Animator>();
		rigid = GetComponent<Rigidbody2D>();
	}

	void Update () {
		this.transform.Translate(Vector3.left * speed * Time.deltaTime); //sets the trajectory for the enemies
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Bullet"){
			anim.SetBool ("Dead", true);
			this.gameObject.tag = "Dead";//change tag to prevent the falling enemy from destroying you
			if (this.gameObject.tag == "Dead") PlayerData.GetInstance.score++;
			GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
			explosionObject.transform.position = this.transform.position; //creates explosion
			rigid.gravityScale = 3; //sets gravity scale to high to simulate fall

		}
		if (coll.gameObject.tag == "Bound" && !isSpecial) Destroy (gameObject);
		if (isSpecial)
			StartCoroutine (manualDestroy());
	}

	IEnumerator manualDestroy (){
		yield return new WaitForSeconds(7f);
		Destroy (this.gameObject);
	}
}
