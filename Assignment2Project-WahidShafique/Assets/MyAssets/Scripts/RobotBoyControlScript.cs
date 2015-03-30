using UnityEngine;
using System.Collections;

public class RobotBoyControlScript : MonoBehaviour {
	//controls robot boy and subsequent interaction
	Animator anim;
	new Rigidbody2D rigidbody2D;
	
	private bool facingRight=true; //Robot boy always faces right when made
	private bool grounded = false; //Robot boy starts a few inches above ground
	private bool moveCheck = true; //checks if you are moving
	private float groundRad = 0.2f;
	private float move;
	private float maximumSpeed = 2f; 
	private float jumpForce = 350f;// /// 

	public Transform groundCheck;
	public LayerMask whatIsGround;
//	public AudioClip jumpClip;


	void Start () {
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		
	}
	
	void FixedUpdate () { //walking 
		move = Input.GetAxis ("Horizontal");
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatIsGround);
		anim.SetBool ("Ground", grounded);
		
		anim.SetFloat ("VSpeed", rigidbody2D.velocity.y);
		
		if (moveCheck) {
			anim.SetFloat("Speed", Mathf.Abs(move));
			GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maximumSpeed,rigidbody2D.velocity.y);
			if (move > 0 && !facingRight)
				Flipper();
			else if (move<0 && facingRight)
				Flipper();
		
		if ( grounded && Input.GetKeyDown(KeyCode.Space)){ //jumping 
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
	//		this.GetComponent<AudioSource>().Play();
			
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){ //jumping 
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
			//		this.GetComponent<AudioSource>().Play();
			
		}
	}
}
	
	void Flipper (){
		
		facingRight = !facingRight;
		
		Vector3 TheScale = transform.localScale;
		
		TheScale.x *= -1;
		
		transform.localScale = TheScale;
	}	
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Death"){
			this.gameObject.tag = "DeadRobot";
			//Destroy(this.gameObject);
			anim.SetBool("Death", true);
			moveCheck = false; //now the player cannot move with arrows
			//this.rigidbody2D.isKinematic = true;
		}
	}
	void OnTriggerStay2D (Collider2D gravArea){
		if (gravArea.tag == "Lev"){
			this.rigidbody2D.gravityScale = -5;
		}
		else this.rigidbody2D.gravityScale = 1;
	}
}

