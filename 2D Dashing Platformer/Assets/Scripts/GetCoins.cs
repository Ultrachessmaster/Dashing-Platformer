using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetCoins : MonoBehaviour {
		
	public static int coins;

	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	void OnLevelWasLoaded (int level) {
		GameObject.FindGameObjectWithTag ("Coin Count").GetComponent <Text> ().text = GetCoins.coins.ToString ();
	}
}
