using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
		public Transform player;
		public float smooth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
				Vector3 destination = new Vector3 (player.position.x, player.position.y, transform.position.z);
				transform.position = destination;//Vector3.Lerp (transform.position, destination, Time.deltaTime * smooth);
	}
}
