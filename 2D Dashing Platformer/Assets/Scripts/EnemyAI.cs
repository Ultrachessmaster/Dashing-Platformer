using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float bounciness;
	public float speed;

	private Rigidbody2D rb2D;
	private bool right;
	private bool onscreen = false;
	private bool closetoedge = false;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void Update () {

	}

	void FixedUpdate () {
		if(onscreen) {
			Vector2 newPosition = transform.position;
			newPosition.x += (right ? speed : -speed);
			rb2D.MovePosition (newPosition);
		}
		//Don't do Physics2D.Racast until slime is no longer near edge. Other wise it will never leave as it will be constantly switching back and forth.
		if(!Physics2D.Raycast (new Vector2(transform.position.x + 0.16f, transform.position.y), -Vector2.up, 0.48f)) {
			right = false;
		}
		if(!Physics2D.Raycast (new Vector2(transform.position.x - 0.16f, transform.position.y), -Vector2.up, 0.48f)) {
			right = true;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		right = !right;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if(!col.collider.CompareTag ("Player"))
			return;
		Vector2 playervelocity = GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ().velocity;
		if(playervelocity.y >= 0) {
			Application.LoadLevel (Application.loadedLevel);
		}
		else {
			gameObject.SetActive (false);
			playervelocity.y = bounciness;
			GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ().velocity = playervelocity;

		}
	}

	void LateUpdate () {
		Vector2 newPosition = transform.position;
		newPosition *= 50f;
		newPosition = new Vector2 (Mathf.Round (newPosition.x), Mathf.Round (newPosition.y));
		newPosition *= (1/50f);
		transform.position = newPosition;
	}


	void OnBecameVisible() {
		onscreen = true;
	}
}
