using UnityEngine;
using System.Collections;

public class TurretEmitter : MonoBehaviour { //This controls the projectiles that emit from the turret
	public GameObject projectile; //projectile to be instantiated by the turret
	public Transform start;//this is the start pos for raycast
	public Transform end; //this is the end pos for raycast
	public bool spotted = false; //this checks if player is in view of raycast
	private float nextFire = 0f;//controls first instance of instantiated object
	
	void Update () {
		Raycast();
		GetComponentInParent<Animator>().SetBool("Spotted",spotted);//trigger barrel recoil
		if (spotted){//once the raycast spots you, start the following firing sequence
		float fireRate = 1f;//1 sec fire rate
		if ( Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector2 position = transform.position;
			Instantiate(projectile, position, transform.rotation);//makes copies of projectile based on position
		}
	}
}
	void Raycast(){
		Debug.DrawLine(start.position, end.position, Color.red);//use to see raycast in scene view 
		spotted = Physics2D.Linecast (start.position, end.position, 1 << LayerMask.NameToLayer("Player"));
		//above sets the spotted bool to true to false accordingly 
	}
}