using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public int pixelsPerUnit;
	public int zoomLevel;
	public float xmin;
	public float xmax;
	public float ymin;
	public float ymax;

	// Update is called once per frame
	void LateUpdate () 
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.45f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			Vector3 fixeddestination = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			fixeddestination *= (float)pixelsPerUnit;
			fixeddestination = new Vector3 (Mathf.Round (fixeddestination.x), Mathf.Round (fixeddestination.y), -1000);
			fixeddestination = fixeddestination / (float)pixelsPerUnit;
			//fixeddestination.x = Mathf.Clamp (fixeddestination.x, xmin + (Screen.width / (float)(2f * pixelsPerUnit * zoomLevel)), xmax - Screen.width);
			//fixeddestination.y = Mathf.Clamp (fixeddestination.y, ymin + Screen.height, ymax - Screen.height);
			transform.position = fixeddestination;

		}

	}
		
}
