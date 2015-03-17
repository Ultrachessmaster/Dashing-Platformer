using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
		void OnTriggerEnter2D (Collider2D col) {
				if (col.GetComponent<Collider2D>().CompareTag ("Die")) {
						Destroy (gameObject);
						Application.LoadLevel (Application.loadedLevel);
				}
		}

		void OnTriggerEnter2D (Collision2D col) {
				if (col.collider.CompareTag ("Die")) {
						Destroy (gameObject);
						Application.LoadLevel (Application.loadedLevel);
				}
		}
}
