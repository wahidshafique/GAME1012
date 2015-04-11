using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour { //controls the projectile ejected from Turret Emitter
	public GameObject explosionPrefab;//object to be instantiated when the projectile is destroyed
	private float speed = 10f;//this is the constant speed in which the projectile will travel at
	
	void Update () {
		this.transform.Translate(Vector3.down * speed * Time.deltaTime);//projectile shoots 'down' when spawned
	}

	void OnTriggerEnter2D (Collider2D coll){//the projectile only interacts with the player and the room
		tag = coll.gameObject.tag;
		if (tag == "Player" || tag == "WallsFloor"){
			Destroy (this.gameObject);//destroy projectile
		}
		GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;//at the projectile's last position
		explosionObject.transform.position = this.transform.position;//..create the explosionPrefab
	}
}