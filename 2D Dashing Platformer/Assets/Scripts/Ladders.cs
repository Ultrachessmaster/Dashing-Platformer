using UnityEngine;
using System.Collections;

public class Ladders : MonoBehaviour {

	public float ladderSpeed;

	private bool isPlayerOn = false;
	private Vector2 playerVelocity;
	private Rigidbody2D playerRigidBody2D;

	void OnTriggerEnter2D (Collider2D col) {
		if(col.CompareTag ("Player")) {
			isPlayerOn = true;

		}
	}

	void FixedUpdate () {
		if(Input.GetAxis ("Vertical") > 0 &  isPlayerOn) {
			playerRigidBody2D = GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ();
			playerVelocity = playerRigidBody2D.velocity;
			playerVelocity.y = ladderSpeed;
			GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ().velocity = playerVelocity;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if(col.CompareTag ("Player")) {
			isPlayerOn = false;

		}
	}
}
