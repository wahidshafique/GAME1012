using UnityEngine;
using System.Collections;

public class RobotBoyControlScript : MonoBehaviour {
	//controls robot boy and subsequent interaction
	Animator anim;
	new Rigidbody2D rigidbody2D;

	private bool facingRight=true; //Robot boy always faces right when made
	private bool grounded = false; //Robot boy starts a few inches above ground
	private bool moveCheck = true; //checks if you are moving
	private float groundRad = 0.2f; //checker radius for ground check
	private float move;
	private float maximumSpeed = 2f; 
	private float jumpForce = 350f; 

	public AudioSource jumpClip;
	public Transform groundCheck;
	public LayerMask whatIsGround;
//	public AudioClip jumpClip;


	void Start () {
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () { //control all movement here 
		move = Input.GetAxis ("Horizontal");//detech horizontal movement
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRad, whatIsGround);//determines what is ground
		anim.SetBool ("Ground", grounded);
		
		anim.SetFloat ("VSpeed", rigidbody2D.velocity.y);//gives values for jump animation tree
		
		if (moveCheck) {
			anim.SetFloat("Speed", Mathf.Abs(move));//gives values for speed, used for trans between walk and run
			GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maximumSpeed,rigidbody2D.velocity.y);
			if (move > 0 && !facingRight)//flips according to orientation
				Flipper();
			else if (move<0 && facingRight)
				Flipper();
		
		if (grounded && Input.GetKeyDown(KeyCode.Space)){ //control jumping
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
					jumpClip.Play();
		}
		/*if (Input.GetKeyDown(KeyCode.UpArrow)){ //rocket activation
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
			//		this.GetComponent<AudioSource>().Play();
			
		}*/
	}
}
	void Flipper (){ //this flips the player
		facingRight = !facingRight;

		Vector3 TheScale = transform.localScale;

		TheScale.x *= -1;

		transform.localScale = TheScale;
	}	
	void OnTriggerEnter2D (Collider2D other){//trigger death sequence 
		if (other.tag == "Death"){
			this.gameObject.tag = "DeadRobot";
			//Destroy(this.gameObject);
			anim.SetBool("Death", true);
			moveCheck = false; //now the player cannot move with arrows

		}
	}
	void OnTriggerStay2D (Collider2D gravArea){//trigger float sequence in level 2 
		if (gravArea.tag == "Lev"){
			this.rigidbody2D.gravityScale = -5;
		}
		else this.rigidbody2D.gravityScale = 1;
	}
}

