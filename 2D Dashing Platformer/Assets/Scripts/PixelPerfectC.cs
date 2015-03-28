using UnityEngine;
using System.Collections;

public class PixelPerfectC : MonoBehaviour {
	void Awake () {
		this.GetComponent <Camera> ().orthographicSize = Screen.height/(2 * 50 * 2f);
	}
}
