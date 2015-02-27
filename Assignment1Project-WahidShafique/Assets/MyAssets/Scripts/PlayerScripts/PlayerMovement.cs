using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//controls player movement as per in class labs
	public float minY = 0.0f, maxY = 10.0f, minX = 0.0f, maxX = 10.0f; //used for clamp

	public float SpeedPerFrame {
		get { return this.speed * Time.deltaTime; }
	}

	[SerializeField] private float speed = 1;
	[SerializeField] private Vector3 direction;

	#region MonoBehaviour
	
	void Update () {
		this.direction = DetectKeyboardInput(); //checks player direction
		Move (this.direction);

		Vector2 currentPosition = transform.position; // get position
		currentPosition.y = Mathf.Clamp( currentPosition.y, minY, maxY);// mod variable to keep y within minY to maxY and vice versa for X
		currentPosition.x = Mathf.Clamp (currentPosition.x, minX, maxX);
		transform.position = currentPosition; //set clamped position
	}
	
	#endregion MonoBehaviour
	
	Vector2 DetectKeyboardInput () {
		//takes in input, pressing all 4 input values causes cancellation of movement
		Vector2 movementDirection = Vector2.zero;

		if (Input.GetKey(KeyCode.UpArrow)) 
			movementDirection += Vector2.up;
		
		if (Input.GetKey(KeyCode.DownArrow)) 
			movementDirection += -1 * Vector2.up;	
		
		if (Input.GetKey(KeyCode.LeftArrow)) 
			movementDirection += -1 * Vector2.right;
		
		if (Input.GetKey(KeyCode.RightArrow)) 
			movementDirection += Vector2.right;
		
		return movementDirection;
	}
	/// <param name="movementDirection">Movement direction.</param>
	void Move (Vector2 movementDirection) {
		this.gameObject.transform.localPosition += ((Vector3)movementDirection * this.SpeedPerFrame); 
	}
}