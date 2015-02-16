using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] private float speed = 1;
	[SerializeField] private Vector3 direction;
	public float minY = 0.0f, maxY = 10.0f, minX = 0.0f, maxX = 10.0f;

	public float SpeedPerFrame {
		get { return this.speed * Time.deltaTime; }
	}

	#region MonoBehaviour
	
	void Update () {
		this.direction = DetectKeyboardInput();
		Move (this.direction);
		Vector3 currentPosition = transform.position; // get position
		currentPosition.y = Mathf.Clamp( currentPosition.y, minY, maxY);// mod variable to keep y within minY to maxY and vice versa for X
		currentPosition.x = Mathf.Clamp (currentPosition.x, minX, maxX);
		transform.position = currentPosition; //set clamped position
	}
	
	#endregion MonoBehaviour
	
	private Vector3 DetectKeyboardInput () {
		Vector3 movementDirection = Vector3.zero;

		if (Input.GetKey(KeyCode.UpArrow)) {
			movementDirection += Vector3.up;
		} 
		
		if (Input.GetKey(KeyCode.DownArrow)) {
			movementDirection += Vector3.down;
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			movementDirection += Vector3.left;
		}
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			movementDirection += Vector3.right;
		}
		return movementDirection;
	}

	private void Move (Vector3 movementDirection) {

		this.gameObject.transform.Translate(movementDirection * this.SpeedPerFrame); 
	}
	
}