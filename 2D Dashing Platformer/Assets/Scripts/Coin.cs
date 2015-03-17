using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
			
	}

		void OnTriggerEnter2D (Collider2D coll) {
				if (coll.GetComponent<Collider2D>().CompareTag ("Player")) {
						GetCoins gc = coll.GetComponentInParent <GetCoins> ();
						gc.getCoins (1);
						Destroy (gameObject);
				}
		}
}
