using UnityEngine;
using System.Collections;

public class TurretEmitter : MonoBehaviour { 
	//This controls the projectiles that emit from the turret
	public GameObject projectile;
	public Transform start;
	public Transform end; 
	public bool spotted = false;
	private float nextFire = 0f;//controls first instance of instantiated object
	
	void Update () {
		Raycast();

		if (spotted){
		float fireRate = 1f;//1 sec fire rate
		if ( Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Vector2 position = transform.position;
			Instantiate(projectile, position, transform.rotation);//makes copies of projectile based on position
		}
	}
}
	void Raycast(){
		Debug.DrawLine(start.position, end.position, Color.red);
		spotted = Physics2D.Linecast (start.position, end.position, 1 << LayerMask.NameToLayer("Player"));
	}
}