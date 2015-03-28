using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float bounciness;
	public float speed;

	private Rigidbody2D rb2D;
	private bool right;
	private bool onscreen = false;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(onscreen) {
			Vector2 newPosition = transform.position;
			float x = newPosition.x;
			if(!right) {
				x -= speed;
				right = false;
			}
			else {
				x += speed;
				right = true;
			}
			newPosition.x = x;
			rb2D.MovePosition (newPosition);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		right = !right;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if(col.collider.CompareTag ("Player") &
			GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ().velocity.y >= 0) {

			Debug.Log ("Player falling" + 
				GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ().velocity.y);
			Application.LoadLevel (Application.loadedLevel);

		}
		else if (col.collider.CompareTag ("Player") & GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ().velocity.y < 0) {
			gameObject.SetActive (false);
			Vector2 playerVelocity = GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ().velocity;
			playerVelocity.y = bounciness;
			GameObject.FindGameObjectWithTag ("Player").GetComponent <Rigidbody2D> ().velocity = playerVelocity;

		}
	}

	void LateUpdate () {
		Vector2 newPosition = transform.position;
		newPosition *= 100f;
		newPosition = new Vector2 (Mathf.Round (newPosition.x), Mathf.Round (newPosition.y));
		newPosition *= (1/100f);
		transform.position = newPosition;
	}


	void OnBecameVisible() {
		onscreen = true;
	}
}
