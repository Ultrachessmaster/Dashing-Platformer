using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {

		public float multiplier;

		void OnTriggerEnter2D(Collider2D col) {
				Vector3 direction = col.GetComponent<Rigidbody2D>().velocity;
				direction.x += (GetComponent<Rigidbody2D>().velocity.x * multiplier);
				float y = direction.y;
				if (GetComponent<Rigidbody2D>().velocity.y > 0) {
						direction.y += GetComponent<Rigidbody2D>().velocity.y;
				}
				direction.y = y;
				col.GetComponent<Rigidbody2D>().velocity = direction;
				Debug.Log (col.name + " " + direction.x);

		}
}
