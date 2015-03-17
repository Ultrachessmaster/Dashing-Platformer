using UnityEngine;
using System.Collections;

public class OrbLighting : MonoBehaviour {

		public float ColorAdjust;
		private float r;
		private float b;
		private float g;

		void OnTriggerEnter2D (Collider2D col) {
				if (col.GetComponent<Collider2D>().CompareTag ("Player")) {
						SpriteRenderer c = GameObject.FindGameObjectWithTag ("Lighting").GetComponent <SpriteRenderer> ();
						Color color = c.color;
						color.r += ColorAdjust;
						color.b += ColorAdjust;
						color.g += ColorAdjust;
						c.color = color;
						Destroy (gameObject);
						Debug.Log ("Lighting");
				}
				Debug.Log ("Enter");
		}

}
