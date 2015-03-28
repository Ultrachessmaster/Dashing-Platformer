using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	// Update is called once per frame
	void LateUpdate () 
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.45f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			Vector3 fixeddestination = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			fixeddestination *= 100;
			Debug.Log (fixeddestination.x);
			fixeddestination = new Vector3 (Mathf.Round (fixeddestination.x), Mathf.Round (fixeddestination.y), -1000);
			Debug.Log (fixeddestination.x);
			fixeddestination = fixeddestination / 100f;
			Debug.Log (fixeddestination.x);
			transform.position = fixeddestination;
		}

	}
}
