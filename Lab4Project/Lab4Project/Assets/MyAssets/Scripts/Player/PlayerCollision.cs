using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{
	Animator anim;
	public GameObject explosion = null;

	void Start () {
		anim = GetComponent <Animator> ();
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		// Instantiate the explosion prefab and store it in the explostionObject local variable.
		GameObject explosionObject = Object.Instantiate(this.explosion) as GameObject;
		
		// Set the global position of the explosion to the global position of the player.
		explosionObject.transform.position = this.gameObject.transform.position;
		
		// Destroy the player.
		if (other.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
			//anim.SetTrigger ("Dead");
		}
	}

	//void killPlayer () {
	//	Destroy (this.gameObject);
	//}
}
