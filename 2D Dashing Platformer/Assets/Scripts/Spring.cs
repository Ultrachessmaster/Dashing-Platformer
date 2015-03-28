using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

	public float offset;
	public float bounciness;

	private bool pickedUp;

	// Use this for initialization
	void Update () {
		if(Input.GetAxis("Run") == 0) {
			transform.parent = null;
			pickedUp = false;
			gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			GetComponent <Collider2D> ().isTrigger = false;
		}
		if (pickedUp) {
			// make sure its exactly on it
			transform.localPosition=(Vector3.zero + (Vector3.up * offset));
			transform.localRotation=Quaternion.identity;
		}
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D coll) {
		if(coll.collider.CompareTag ("Player") & !pickedUp & Input.GetAxis ("Run") > 0) {
			transform.parent=coll.transform;
			// make sure its exactly on it
			transform.localPosition=(Vector3.zero + (Vector3.up * offset));
			transform.localRotation=Quaternion.identity;
			pickedUp = true;
			gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent <Collider2D> ().isTrigger = true;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(col.CompareTag ("Player") & !pickedUp) {
			GameObject.FindWithTag ("Player").GetComponent <Rigidbody2D> (). velocity = new Vector2 
			(GameObject.FindWithTag ("Player").GetComponent <Rigidbody2D> (). velocity.x, bounciness);
		}
	}


}
