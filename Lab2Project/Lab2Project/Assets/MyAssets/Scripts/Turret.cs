using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public Rotation bodyRotation=null;
	public Rotation gunRotation=null;
	public float rotationSpeed=1;
	private Rotation turrentRotation=null;
	public Transform spawner=null;


	void awake(){
		this.turrentRotation = this.gameObject.GetComponent<Rotation> ();
		}
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		CheckInput();
	}

	private void CheckInput(){

		RotateBodyInput();
		RotateGunInput ();
		Move ();
		RotateTurret ();
		FireInput ();
	}
	private void FireInput(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject projectile = Instantiate (this.projectile  Prefab) as GameObject;
			projectile.transform.position=this.spawner.postion;
			projectile.transform.position=this.spawner.postion;
				}
		}
	private void RotateTurret(){
				if (Input.GetKey (KeyCode.A)) {
						this.turrentRotation.Rotate (-this.rotationSpeed);
				}
				if (Input.GetKey (KeyCode.D)) {
			this.turrentRotation.Rotate (this.rotationSpeed);
				}
		}
	private void Move(){
				if (Input.GetKey (KeyCode.W)) {
						this.transform.Translate (Vector3.forward);
				}
				if (Input.GetKey (KeyCode.S)) {
						this.transform.Translate (Vector3.back);
				}
		}

	private void RotateBodyInput(){
		if (Input.GetKey (KeyCode.RightArrow)){
			this.bodyRotation.Rotate(this.rotationSpeed);
	}
		if (Input.GetKey (KeyCode.LeftArrow)){
			this.bodyRotation.Rotate(-this.rotationSpeed);
		}
	}
	private void RotateGunInput (){
		if (Input.GetKey (KeyCode.UpArrow)){
			this.gunRotation.Rotate(-this.rotationSpeed);
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			this.gunRotation.Rotate(-this.rotationSpeed);
		}
}
		}