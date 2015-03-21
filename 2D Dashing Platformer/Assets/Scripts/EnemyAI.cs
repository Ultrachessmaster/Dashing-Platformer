using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float bounciness;

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
				x--;
				right = false;
			}
			else {
				x++;
				right = true;
			}
			newPosition.x = x;
			rb2D.MovePosition (newPosition);
		}
		Vector2 position = transform.position;
		float y = transform.position.y;
		y += 10.1f;
		position.y = y;
		RaycastHit2D rh = Physics2D.Raycast(position, Vector2.up, 1);
		if(rh.collider != null) {
			if (rh.collider.CompareTag("Player")) {
				rh.collider.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * bounciness);
				gameObject.SetActive (false);
				Debug.Log("Player Above " + gameObject);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(right)
			right = false;
		else
			right = true;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if(col.collider.CompareTag ("Player")) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	void OnBecameVisible() {
		onscreen = true;
	}
}
