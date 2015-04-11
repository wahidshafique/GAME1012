using UnityEngine;
using System.Collections;

public class RobotBoyControlScript : MonoBehaviour {
	//controls robot boy and subsequent interaction
	Animator anim;
	new Rigidbody2D rigidbody2D;

	//player//
	private bool roll = false;
	private bool jump = false; //triggers jump in fixed update from update because doing it in FU causes jumpForce issue
	private bool facingRight=true; //Robot boy always faces right when made
	private bool grounded = false; //Robot boy starts a few inches above ground, and his default mode is not grounded
	private bool moveCheck = true; //checks if you are moving, useful for when you die (bool can simple be turned to false)
	private float groundRad = 0.2f; //checker radius for ground check
	private float move; //numerical representation of movement direction +1 is forward, -1 
	private float maximumSpeed = 2f; //you cannot extend beyond this speed constraint
	private float jumpForce = 350f; //controls your maximum jump height 
	public AudioSource jumpClip;
	public AudioSource rollClip;
	public Transform groundCheck;
	public LayerMask whatIsGround;//you can define ground via inspector

	//bomb//
	private bool bombActive = false; //this bool checks if you have interacted with bombAmmo yet
	private int bombCount = 3; //your bomb items to use 
	private float nextFire = 0f;//controls first instance of instantiated bomb
	public Transform spawner; //used exclusively for spawning bombs 
	public GameObject[] bombsUI;//this array houses the bomb UI that pops up 
	public GameObject bomb;//once you have collected bombAmmo, this is used for creating the actual bombs 
	public AudioSource bombCollectClip;

	//jetpack//
	private bool rocketActive = false;
	private float force = 25f;//force of downward thrust 
 	private float moveUpDown;
	public GameObject flame; 
	public GameObject rocketPickup;
	public GameObject rocket;
	public float impactTolerance = 16f;

	void Start () {
		bombsUI = GameObject.FindGameObjectsWithTag("BombUI");//populates bombsUI array
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () { //control all movement here 
		move = Input.GetAxis ("Horizontal");//detect horizontal movement
		moveUpDown = Input.GetAxis("Vertical");//detect vertical movement
		
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

			if (jump) {//see's if you indicated jumping in Update, and acts upon that in Fixed updates
				rigidbody2D.AddForce (new Vector2 (0, jumpForce));//..this was done to mitigate strange jump problems
				if(!roll) jumpClip.Play ();	                     //..wherein robot boy would periodically jump very high
				jump = false; 
				roll = false;
			}
		
	if (rocketActive){
		if (moveUpDown > 0){
				Vector2 globalMovementDirection = this.transform.TransformDirection(Vector2.up);
				this.GetComponent<Rigidbody2D>().AddForce(globalMovementDirection * this.force);
				flame.SetActive(true);
			} else flame.SetActive(false);
		}
	}
}
	void Update(){
		triggerBomb();
		if (grounded && Input.GetKeyDown(KeyCode.Space)){ //control jumping, done in F-U to stop inconsistent jump height
			jump = true;
		} 
		if (grounded && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
			if (grounded && Input.GetKeyDown(KeyCode.Space)){
				roll = true;
				rollClip.Play();
			}
		}
	}

	void Flipper (){ //this flips the player in the x axis 
		facingRight = !facingRight;

		Vector3 TheScale = transform.localScale;

		TheScale.x *= -1;

		transform.localScale = TheScale;
	}	
	void OnTriggerEnter2D (Collider2D other){//trigger death sequence 
		if (other.tag == "Death"){
			this.gameObject.tag = "DeadRobot";//ensures that no other interactions with RB are possible 
			anim.SetBool("Death", true);
			moveCheck = false; //now the player cannot move with arrows
		}
		if (other.tag == "BombAmmo"){
			bombCollectClip.Play();//play the collection audio
			for (int i = 0; i < bombsUI.Length; i++){//this makes the bombsUI array elements visible
				bombsUI[i].GetComponent<SpriteRenderer>().enabled = true;
			}
			bombActive = true; //let all dependent code know that you have the bomb
			GameObject bombAmmo = GameObject.Find("BombAmmo");//makes the bomb ammo object inActive
			bombAmmo.SetActive(false);
	}
		if (other.tag == "RocketPickup"){
			Destroy(rocketPickup);
			rocket.SetActive(true);
			rocketActive = true;
		}
}
	void OnTriggerStay2D (Collider2D gravArea){//trigger float sequence in level 2 
		if (gravArea.tag == "Lev"){
			this.rigidbody2D.gravityScale = -1;//if you are in the lev field, your gravity is lowered
		}
		else this.rigidbody2D.gravityScale = 1;//else it is normal
	}
	void triggerBomb(){
	if (bombActive){
		float fireRate = 1f;//1 sec fire rate
		if ( Time.time > nextFire && Input.GetKey("b") && bombCount > 0) {
			bombCount--;
			bombsUI[bombCount].GetComponent<SpriteRenderer>().enabled = false;//every time you fire, erase 1 UI element
			nextFire = Time.time + fireRate;
			Vector2 position = transform.position;
			GameObject bombInstance = Instantiate(bomb, spawner.position, spawner.rotation)as GameObject;//makes copies of projectile based on position
			bombInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,0.07f));//give bomb a little 'push' up when created
			}
		}
	}
	void OnCollisionEnter2D (Collision2D collision)
	{	
		if (collision.gameObject.CompareTag("WallsFloor")) {
			if (collision.relativeVelocity.magnitude > this.impactTolerance){
				anim.SetBool("Death", true);
				this.gameObject.tag = "DeadRobot";
				moveCheck = false;
			}
		}
	}
}


