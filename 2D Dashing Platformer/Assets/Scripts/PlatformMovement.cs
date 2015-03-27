using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

		public Transform EndPosistion;
		public Transform StartPosistion;
		public Transform Platform;
		public float speed;
		private Transform destination;
		private Vector3 direction;

		void Start () {
				SetDestination (StartPosistion);
		}

	// Use this for initialization
	void FixedUpdate () {
				Platform.GetComponent<Rigidbody2D>().MovePosition(Platform.position + direction * speed * Time.fixedDeltaTime);

				if(Vector3.Distance (Platform.position, destination.position) < speed * Time.fixedDeltaTime) {
						SetDestination (destination == StartPosistion ? EndPosistion : StartPosistion);
				}
	}
	
	// Update is called once per frame
		void OnDrawGizmos () {
				Gizmos.color = Color.green;
				Gizmos.DrawWireCube (StartPosistion.position, Platform.localScale);
				Gizmos.color = Color.magenta;
				Gizmos.DrawWireCube (EndPosistion.position, Platform.localScale);
		}

		void SetDestination (Transform dest) {
				destination = dest;
				direction = (destination.position - Platform.position).normalized;
		}


}
