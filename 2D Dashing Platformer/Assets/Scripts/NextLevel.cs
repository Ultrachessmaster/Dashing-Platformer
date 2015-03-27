using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			Application.LoadLevel ("Level 2");
			Debug.Log ("siruegniusoegnesiughn");
		}
	}

}
