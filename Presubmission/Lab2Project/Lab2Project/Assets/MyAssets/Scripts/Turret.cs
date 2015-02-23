using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public Rotation bodyRotation=null;
	public Rotation gunRotation=null;
	public float rotationSpeed=1;
	public Rotation turretRotation=null;
	
	void awake(){
		this.turretRotation = this.gameObject.GetComponent<Rotation> ();
		}

	void Update () {
		CheckInput();
	}

	private void CheckInput(){

		RotateBodyInput();
		RotateGunInput ();
		Move ();
		RotateTurret ();
	}
	private void RotateTurret(){
				if (Input.GetKey (KeyCode.A)) {
						this.turretRotation.Rotate (-this.rotationSpeed);
				}
				if (Input.GetKey (KeyCode.D)) {
			this.turretRotation.Rotate (this.rotationSpeed);
				}
		}
	private void Move(){
				if (Input.GetKey (KeyCode.W)) {
						this.transform.Translate (transform.forward);
				}
				if (Input.GetKey (KeyCode.S)) {
						this.transform.Translate (-transform.forward);
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
			this.gunRotation.Rotate(this.rotationSpeed);
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			this.gunRotation.Rotate(-this.rotationSpeed);
		}
}
		}