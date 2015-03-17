using UnityEngine;
using System.Collections;

public class PlatformerMovement : MonoBehaviour {

		public float speed;
		public float multiplier;
		public float jumpForce;
		public float doubleJumpForce;
		public int jumpTime;
		public int doubleJumpTime;
		public int doubleJumpReleaseTime;
		public int dashSpeed;
		public int dashTime;
		public int fallTime;
		private bool left;
		private bool right;
		private bool isGrounded;
		private bool jumping;
		private int timer = 0;
		private bool doubleJump = false;
		private int doubleJumpTimer = 0;
		private bool letGo;
		private bool dash;
		private float originalGravityScale;
		private int dashTimer = 0;
		private int fallTimer = 0;
		private bool cantJump = false;

	// Use this for initialization
	void Start () {
				originalGravityScale = GetComponent<Rigidbody2D>().gravityScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
				if (Input.GetAxis ("Run") == 0)
				{
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
				if (!isGrounded) {
						fallTimer++;
						if (fallTimer > fallTimer) {

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
						if (left)
						{
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
