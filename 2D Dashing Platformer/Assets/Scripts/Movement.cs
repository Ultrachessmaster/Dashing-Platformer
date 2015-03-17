using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

		public float speed;
		public float multiplier;
		public float jumpHeight;
		public float jumpScale;
		public float fallForceStart = 1;
		public float fallForceAccelaration;
		public float dashSpeed;
		public float dashTime;
		public float rateOfFall;
		public float doubleJumpModifier;
		private bool isJumping = false;
		private float OriginalFallForce;
		private bool letGoOfButton = false;
		private int timer;
		private bool dash = false;
		private int dashTimer = 0;
		private float gravityScale;
		private bool left;
		private bool right;
		private bool isFalling;
		private float fallForceFalling = 19f;
		private float fallingRate;
		private bool isDoubleJumping = false;
		private int doubleJumpTimer = 0;
		

	// Use this for initialization
	void Start () {
				OriginalFallForce = fallForceStart;
				gravityScale = GetComponent<Rigidbody2D>().gravityScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
				if (Input.GetAxis ("Run") == 0 & !dash)
				{
						if (Input.GetAxis ("Horizontal") > 0) {
								transform.Translate (Vector3.right * speed);
								right = true;
								left = false;
						}
						if (Input.GetAxis ("Horizontal") < 0) {
								transform.Translate (Vector3.left * speed);
								right = false;
								left = true;
						}
				}
				if(Input.GetAxis ("Run") > 0 & !dash) {
						if (Input.GetAxis ("Horizontal") > 0) {
								transform.Translate (Vector3.right * speed * multiplier);
								right = true;
								left = false;
						}
						if (Input.GetAxis ("Horizontal") < 0) {
								transform.Translate (Vector3.left * speed * multiplier);
								right = false;
								left = true;
						}
				}
				if(Input.GetAxis ("Jump") > 0 & timer <= 20 &!isFalling &!isDoubleJumping) {
						transform.Translate (Vector3.up * jumpHeight);
						isJumping = true;
						timer++;

				}
				if (timer > 20 & !letGoOfButton &!dash &!isDoubleJumping) {
						// the fall force for when he is just jumping
						fallForceFalling += fallForceAccelaration/(60 - fallingRate);
						transform.Translate (Vector3.up/ (fallForceFalling * jumpScale));
						fallingRate += rateOfFall;
						Debug.Log ("Rate of fall = " + fallingRate + "fallForceFalling = " + fallForceFalling);
				}
				if (isJumping & !dash & letGoOfButton & doubleJumpTimer <= 10) {
						// the fall force for his double jump
						GetComponent<Rigidbody2D>().velocity = Vector2.zero;
						fallForceStart += fallForceAccelaration/1.5f;
						transform.Translate ((Vector3.up/ (fallForceStart * jumpScale)) * doubleJumpModifier);
						isDoubleJumping = true;
						doubleJumpTimer++;
				}
				if (doubleJumpTimer > 10) {
						GetComponent<Rigidbody2D>().AddForce (Vector2.up * -4.5f);
				}
				if (isFalling) {
						transform.Translate (Vector3.down / 12); 
				}
				if (Input.GetAxis ("Jump") == 0 & isJumping & !isFalling) {
						// if the player isn't pushing the button and he's jumping willingly and is not falling then he's let go of the button
						letGoOfButton = true;
				}

				if (Input.GetAxis ("Jump") > 0 & isJumping & letGoOfButton) {
						dash = true;

				}
				if (dash & dashTimer <= dashTime) {
						GetComponent<Rigidbody2D>().gravityScale = 0;
						GetComponent<Rigidbody2D>().velocity = Vector2.zero;
						if (left) {
								transform.Translate (Vector3.left * dashSpeed);
						}
						if (right) {
								transform.Translate (Vector3.right * dashSpeed);
						}
						dashTimer++;
						letGoOfButton = false;
				}
				else 
				{
						GetComponent<Rigidbody2D>().gravityScale = gravityScale;
						dash = false;
				}
	}

		void OnTriggerEnter2D (Collider2D col) {
				if (col.GetComponent<Collider2D>().CompareTag ("Ground")) {
						//reset all variables
						isJumping = false;
						fallForceStart = OriginalFallForce;
						timer = 0;
						letGoOfButton = false;
						dashTimer = 0;
						isFalling = false;
						fallingRate = 0;
						fallForceFalling = 15.5f;
						isDoubleJumping = false;
						doubleJumpTimer = 0;
				}
			
		}

		void OnTriggerExit2D (Collider2D col) {
				if (col.GetComponent<Collider2D>().CompareTag ("Ground") & Input.GetAxis ("Jump") == 0) {
						//to make sure player doesn't jump, and acelarates as he falls.
						isJumping = true;
						letGoOfButton = false;
						isFalling = true;
				}
		}
}
