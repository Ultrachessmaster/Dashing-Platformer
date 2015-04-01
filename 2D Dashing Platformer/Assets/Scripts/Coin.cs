using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
			
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.GetComponent<Collider2D>().CompareTag ("Player")) {
			GetCoins.coins++;
			GameObject.FindGameObjectWithTag ("Coin Count").GetComponent <Text> ().text = GetCoins.coins.ToString ();
			GameObject.Find ("coinSound").GetComponent <AudioSource> ().Play ();
			Destroy (gameObject);
		}
	}



}
