using UnityEngine;
using System.Collections;

public class PlatformerMovement : MonoBehaviour {
		//how fast the player can go
		public float speed;
		//how much the player increases speed when running / pressing shift
		public float multiplier;
		//how high the player jumps
		public float jumpForce;
		//how high the player double jumps
		public float doubleJumpForce;
		//how long the jump lasts
		public int jumpTime;
		//how long the double jump lasts
		public int doubleJumpTime;
		//how long before the player can let go of the space bar to double jump
		public int doubleJumpReleaseTime;
		//how fast the player dashes through the air
		public float dashSpeed;
		//how long the player dashes
		public int dashTime;
		//in what direction the player moves
		private bool left;
		private bool isGrounded;
		private bool jumping;
		private int timer = 0;
		private bool doubleJump = false;
		private int doubleJumpTimer = 0;
		private bool letGo;
		private bool dash;
		private float originalGravityScale;
		private int dashTimer = 0;

	// Use this for initialization
	void Start () {
		originalGravityScale = GetComponent<Rigidbody2D>().gravityScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Run") == 0) {
			if (Input.GetAxis ("Horizontal") > 0) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
				left = false;
			}
			if (Input.GetAxis ("Horizontal") < 0) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D>().velocity.y);
				left = true;
			}
			if (Input.GetAxis ("Horizontal") == 0) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x/1.5f, GetComponent<Rigidbody2D>().velocity.y);
			}
		}
		if(Input.GetAxis ("Run") > 0) {
			if (Input.GetAxis ("Horizontal") > 0) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (speed * multiplier, GetComponent<Rigidbody2D>().velocity.y);
				left = false;
			}
			if (Input.GetAxis ("Horizontal") < 0) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed * multiplier, GetComponent<Rigidbody2D>().velocity.y);
				left = true;
			}
			if (Input.GetAxis ("Horizontal") == 0) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x/2, GetComponent<Rigidbody2D>().velocity.y);
			}
		}
		if (Input.GetAxis ("Jump") > 0 & timer <= jumpTime &isGrounded &!doubleJump &!letGo) {
			jumping = true;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpForce);
			timer++;
		}
		else if (Input.GetAxis ("Jump") == 0 & jumping) {
			if (timer >= doubleJumpReleaseTime) {
				doubleJump = true;
			}
			letGo = true;

		}
		if (letGo & Input.GetAxis ("Jump") > 0) {
			dash = true;
		}
		if (dash & dashTimer <= dashTime) {
			if (left) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-dashSpeed, 0);
			}
			if(!left) {
				GetComponent<Rigidbody2D>().velocity = new Vector2 (dashSpeed, 0);
			}
			GetComponent<Rigidbody2D>().gravityScale = 0;
			dashTimer++;

		}
		else {
			GetComponent<Rigidbody2D>().gravityScale = originalGravityScale;
			dash = false;
		}
		if (doubleJump & doubleJumpTimer <= doubleJumpTime) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, doubleJumpForce);
			doubleJumpTimer++;
		}

	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.GetComponent<Collider2D>().CompareTag ("Ground")) {
			//reset all variables
			jumping = false;
			isGrounded = true;
			doubleJump = false;
			letGo = false;
			dash = false;
			dashTimer = 0;
			timer = 0;
			doubleJumpTimer = 0;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.GetComponent<Collider2D>().CompareTag ("Ground") & !jumping) {
			isGrounded = false;
			letGo = true;

		}
	}
}
