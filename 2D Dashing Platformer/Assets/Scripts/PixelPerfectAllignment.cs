using UnityEngine;
using System.Collections;

public class PixelPerfectAllignment : MonoBehaviour {

	public int pixelsToUnits;

	void Start() {
		Vector2 fixedPosition = transform.position;
		fixedPosition *= (float)pixelsToUnits;
		fixedPosition = new Vector2(Mathf.Round (fixedPosition.x), Mathf.Round (fixedPosition.y));
		fixedPosition = fixedPosition / (float)pixelsToUnits;
		transform.position = fixedPosition;

	}
}
